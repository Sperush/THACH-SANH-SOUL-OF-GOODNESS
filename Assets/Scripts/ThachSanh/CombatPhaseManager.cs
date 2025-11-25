using UnityEngine;
using UnityEngine.UI;

// Quản lý chuyển đổi giữa hai phong cách chiến đấu
public class CombatPhaseManager : MonoBehaviour
{
    public Inventory inventory;
    public Animator animator;
    public PlayerHealth playerHealth;
    public Button btnSkill3;
    public AxeAttack axeAttack;
    [Header("Attack Settings")]
    public Transform attackOrigin;
    public float attackRange = 2f;
    public LayerMask enemyLayer;

    [Header("Combo Settings")]
    public int maxCombo = 4;
    private int comboStep = 0;

    void Update()
    {
        if (playerHealth.isDie) return;
        if (animator.GetBool("IsStunned")) animator.SetBool("IsStunned", false);
        if (playerHealth.isStun && playerHealth.TimeStun > 0)
        {
            if(!animator.GetBool("IsStunned")) animator.SetBool("IsStunned", true);
            playerHealth.TimeStun -= Time.deltaTime;
            if (playerHealth.TimeStun <= 0f)
            {
                playerHealth.isStun = false;
                playerHealth.TimeStun = 1.5f;
            }
            return;
        }
#if !(UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR)
        if (Input.GetMouseButtonDown(0)) PerformAttack();
#endif
    }

    public void PerformAttack()
    {
        if (animator.GetCurrentAnimatorStateInfo(1).IsTag("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsTag("AttackSkill") || animator.GetCurrentAnimatorStateInfo(0).IsName("Gathering")) return;
        if (comboStep >= maxCombo) comboStep = 0;
        bool isAttack = false;
        Collider[] hits = Physics.OverlapSphere(attackOrigin.position, attackRange, enemyLayer);
        bool isFinnal = comboStep == 3;
        bool isWeapon = inventory.isUseWeapons();
        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out EnemyHealth enemy))
            {
                enemy.TakeDamage(isFinnal ? 50 : isWeapon ? 10 : 5);
                enemy.isStun = isFinnal;
                isAttack = true;
            } else if (hit.transform.parent.TryGetComponent(out BossLizard boss))
            {
                boss.TakeDamage(isFinnal ? 50 : isWeapon ? 10:5);
                boss.isStun = isFinnal;
                isAttack = true;
            } else if (hit.TryGetComponent(out Item item) && isWeapon)
            {
                item.CountBreak--;
                if (item.CountBreak <= 0) item.Spawn();
            }
        }
        if (isAttack && isWeapon)
        {
            comboStep++;
        }
        animator.SetInteger("AttackIndex", comboStep);
        animator.SetTrigger("Attack");
    }
    public void UseSkillAttack(int idx)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("AttackSkill")) return;
        int dameSkill = 10;
        switch (idx)
        {
            case 0:
                dameSkill = 50;
                animator.SetTrigger("isAttackSkill1");
                break;
            case 1:
                dameSkill = 20;
                animator.SetTrigger("isAttackSkill2");
                break;
            case 2:
                dameSkill = 100;
                animator.SetTrigger("isAttackSkill3");
                break;
        }
        axeAttack.damage = dameSkill;
    }
    public void UseSkillSurvival(int idx)
    {
        switch (idx)
        {
            case 0:
                animator.SetTrigger("IsSpinAttack");
                break;
            case 1:
                animator.SetTrigger("IsSpinAttack");
                break;
            case 2:
                animator.SetTrigger("IsSpinAttack");
                break;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
    }
}