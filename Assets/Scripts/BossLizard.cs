using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossLizard : MonoBehaviour
{
    [Header("References")]
    public Animator animator;
    public SoulMeter playerSoul;
    public Transform weakSpot;
    public Transform player;
    public PlayerHealth playerHealth;
    public LayerMask playerLayer;
    [Header("Attack Points")]
    public Transform attackOrigin;
    [Header("Stats")]
    public Image fillImage;
    public float maxHealth = 500;
    public float currentHealth;
    private int phase = 1;
    private float fullWidth;

    [Header("Attack Settings")]
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    private float attackTimer = 0f;
    public float moveSpeed = 3f;
    private int comboStep = 0;
    private bool isDead = false;
    private bool isAttacking = false;
    public bool isStun;
    private float TimeStun = 2f;
    [Header("AI Settings")]
    public float pathUpdateRate = 0.3f;
    private NavMeshAgent agent;

    void Start()
    {
        fullWidth = fillImage.rectTransform.sizeDelta.x;
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
            agent.speed = moveSpeed;
        StartCoroutine(UpdatePathRoutine());
    }
    IEnumerator UpdatePathRoutine()
    {
        // Đảm bảo không chạy nếu không có Agent hoặc Player
        if (agent == null || player == null) yield break;

        while (true)
        {
            // Tạm dừng Coroutine trong 0.3 giây
            yield return new WaitForSeconds(pathUpdateRate);

            // CHỈ CẬP NHẬT ĐIỂM ĐẾN NẾU BOSS ĐANG KHÔNG BỊ DỪNG LẠI
            if (agent.isActiveAndEnabled && !agent.isStopped && !isStun && !isAttacking)
            {
                // Lệnh tính toán đường đi TỐN KÉM đã được chuyển vào đây
                agent.SetDestination(player.position);
            }
        }
    }

    public void SetHP(float value)
    {
        currentHealth = Mathf.Clamp(value, 0, maxHealth);
        float ratio = currentHealth / maxHealth;

        var size = fillImage.rectTransform.sizeDelta;
        size.x = fullWidth * ratio;
        fillImage.rectTransform.sizeDelta = size;
    }

    void Update()
    {
        if (isDead || player == null) return;
        if (isStun && TimeStun > 0)
        {
            TimeStun -= Time.deltaTime;
            if (TimeStun <= 0f)
            {
                isStun = false;
                TimeStun = 2f;
            }
            animator.SetTrigger("Hit");
            return;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) return;
        // Tăng timer tấn công
        attackTimer += Time.deltaTime;

        // Khoảng cách đến người chơi
        // TỐI ƯU HÓA: Dùng sqrMagnitude
        float sqrDistance = (transform.position - player.position).sqrMagnitude;
        float sqrAttackRange = attackRange * attackRange;

        // Nếu đang tấn công thì không di chuyển
        if (isAttacking)
        {
            animator.SetFloat("Speed", 0);
            return;
        }

        // Nếu trong tầm đánh
        if (sqrDistance <= sqrAttackRange)
        {
            agent.isStopped = true;

            // Hướng về player
            Vector3 lookDir = (player.position - transform.position).normalized;
            lookDir.y = 0;
            if (lookDir != Vector3.zero) transform.rotation = Quaternion.LookRotation(lookDir);
            if (attackTimer >= attackCooldown)
            {
                animator.SetFloat("Speed", 0);
                StartCoroutine(Attack());
            }
        }
        else
        {
            // Di chuyển đến player
            if (agent != null)
            {
                agent.isStopped = false;
                float currentSpeed = agent.velocity.magnitude;
                animator.SetFloat("Speed", currentSpeed);
                animator.SetFloat("Attack", 0);
            }
        }
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        attackTimer = 0f;
        if (comboStep > 4) comboStep = 1;
        comboStep++;
        animator.SetFloat("Attack", comboStep == 4 ? 1f:0.3f); 
        yield return new WaitForSeconds(0.6f); // delay trúng đòn theo animation

        Collider[] hits = Physics.OverlapSphere(attackOrigin.position, attackRange, playerLayer);
        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out PlayerHealth pl))
            {
                pl.TakeDamage(10);
                pl.isStun = comboStep == 4;
                pl.TimeStun *= phase == 2 ? 2 : 1;
                if (pl.isDie) player = null;
            }
        }

        yield return new WaitForSeconds(0.7f); // cooldown giữa 2 lần đánh
        isAttacking = false;
    }

    public void TakeDamage(float dmg, bool isWeakPoint = false)
    {
        if (isDead || playerHealth.isDie) return;

        if (isWeakPoint) dmg *= 2f;
        currentHealth -= dmg;
        animator.SetTrigger("Hit");

        if (currentHealth <= maxHealth * 0.6f && phase == 1)
        {
            phase = 2;
            //animator.SetTrigger("Phase2");
            fillImage.color = Color.yellow;
        }

        if (currentHealth <= maxHealth * 0.3f && phase == 2)
        {
            phase = 3;
            //animator.SetTrigger("Phase3");
            fillImage.color = Color.red;
            StartCoroutine(PoisonPhase());
        }
        SetHP(currentHealth);
        if (currentHealth <= 0)
            Die();
    }

    IEnumerator PoisonPhase()
    {
        while (phase == 3 && !isDead)
        {
            playerSoul.Decrease(1);
            yield return new WaitForSeconds(2f);
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        if (agent != null) agent.isStopped = true;
        StopAllCoroutines();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
