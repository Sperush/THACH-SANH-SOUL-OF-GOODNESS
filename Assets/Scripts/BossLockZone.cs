using UnityEngine;

public class BossLockZone : MonoBehaviour
{
    private BossLizard boss;

    void Start()
    {
        boss = GetComponentInParent<BossLizard>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        var cam = FindObjectOfType<CameraManager>();
    //        cam.EnterLockZone(boss.weakSpot != null ? boss.weakSpot : boss.transform);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        var cam = FindObjectOfType<CameraManager>();
    //        cam.ExitLockZone();
    //    }
    //}
}
