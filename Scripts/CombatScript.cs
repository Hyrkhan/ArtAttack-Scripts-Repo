using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class CombatScript : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = .5f;
    public LayerMask enemyLayers;
    public Animator animator;

    private int attackDamage = 5;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    public AudioSource NormAttackAudio;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            
            if(CrossPlatformInputManager.GetButton("Attack"))
            {
                Attack();
                animator.SetBool("isNormAttack", true);
                nextAttackTime = Time.time + 0.3f / attackRate;
                NormAttackAudio.Play();
            }
            else
            {
                animator.SetBool("isNormAttack", false);
                NormAttackAudio.Stop();
            }
            
        }

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != null && enemy.GetComponent<EnemyScript>() != null)
            {
                enemy.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void IncreaseAttack(int attackup)
    {
        attackDamage += attackup;
    }
}
