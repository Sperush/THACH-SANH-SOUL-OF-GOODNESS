using UnityEngine;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour
{
    public CinemachineFreeLook freeLookCam;
    public CinemachineTargetGroup targetGroup;
    public Transform player;
    public GameObject Hpbar;
    public PlayerHealth playerHealth;

    [Header("Lock Settings")]
    public float lockDistance = 15f; // Giá trị khoảng cách khóa (thực tế)
    private float defaultMiddleHeight = 5f;
    private float lockMiddleHeight = 2f;     // khi khóa
    public float smoothSpeed = 4f;           // tốc độ lerp
    private float targetMiddleHeight;


    [Header("Optimization Settings")]
    public float searchInterval = 0.25f;

    private PlayerController playerController;
    private BossLizard[] bossList;

    // BIẾN MỚI: Lưu bình phương khoảng cách khóa
    private float lockSqrDistance;

    // BIẾN MỚI: Cache bình phương khoảng cách tìm được
    private float cachedNearestSqrDistance;
    private Transform cachedNearestBoss;
    private bool isLocked = false;
    void Start()
    {
        targetMiddleHeight = defaultMiddleHeight;
        freeLookCam.m_Orbits[1].m_Height = defaultMiddleHeight;
        playerController = player.GetComponent<PlayerController>();

        // TÍNH TOÁN BÌNH PHƯƠNG KHOẢNG CÁCH KHÓA MỘT LẦN
        lockSqrDistance = lockDistance * lockDistance;

        bossList = FindObjectsOfType<BossLizard>();
        StartCoroutine(FindNearestBossRoutine());
    }

    IEnumerator FindNearestBossRoutine()
    {
        while (true)
        {
            if (bossList == null || bossList.Length == 0 || playerHealth.isDie)
            {
                cachedNearestBoss = null;
                cachedNearestSqrDistance = Mathf.Infinity;
                yield return new WaitForSeconds(1f);
                continue;
            }
            yield return new WaitForSeconds(searchInterval);
            Transform nearest = null;   
            float minSqrDistance = Mathf.Infinity;
            Vector3 playerPos = player.position;
            foreach (var boss in bossList)
            {
                if (boss == null || boss.transform == null || !boss.gameObject.activeSelf || boss.currentHealth <= 0) continue;
                float sqr = (playerPos - boss.transform.position).sqrMagnitude;
                if (sqr < minSqrDistance)
                {
                    minSqrDistance = sqr;
                    nearest = boss.transform;
                }
            }
            cachedNearestBoss = nearest;
            cachedNearestSqrDistance = minSqrDistance;
        }
    }

    void Update()
    {
        Transform nearest = cachedNearestBoss;
        if (nearest == null)
        {
            if (isLocked) UnlockCamera();
            isLocked = false;
        }
        else
        {
            if (cachedNearestSqrDistance < lockSqrDistance)
            {
                if (!isLocked) LockCamera(nearest);
                isLocked = true;
            }
            else
            {
                if (isLocked) UnlockCamera();
                isLocked = false;
            }
        }
        if(freeLookCam.m_Orbits[1].m_Height != targetMiddleHeight) freeLookCam.m_Orbits[1].m_Height = Mathf.Lerp(freeLookCam.m_Orbits[1].m_Height, targetMiddleHeight, Time.deltaTime * smoothSpeed);
    }
    void LockCamera(Transform nearest)
    {
        targetMiddleHeight = lockMiddleHeight;
        targetGroup.m_Targets[0].target = player;
        targetGroup.m_Targets[1].target = nearest;
        targetGroup.m_Targets[0].weight = targetGroup.m_Targets[1].weight = 1;
        freeLookCam.LookAt = targetGroup.transform;
        playerController.lockTarget = nearest;
        if (!Hpbar.activeSelf) Hpbar.SetActive(true);
    }

    void UnlockCamera()
    {
        targetMiddleHeight = defaultMiddleHeight;
        targetGroup.m_Targets[0].target = player;
        targetGroup.m_Targets[1].target = null;
        freeLookCam.LookAt = player;
        playerController.lockTarget = null;
        if (Hpbar.activeSelf) Hpbar.SetActive(false);
    }
}