using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public int damage;
    public bool isStun;
    public CombatPhaseManager combat;   
    private void OnTriggerEnter(Collider other)
    {
        if (!combat.animator.GetCurrentAnimatorStateInfo(0).IsTag("AttackSkill")) return;
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
            enemy.isStun = isStun;
        }
        else if (other.CompareTag("Boss"))
        {
            BossLizard boss = other.GetComponentInParent<BossLizard>();
            boss.TakeDamage(damage);
            boss.isStun = isStun;
        }
    }
}
