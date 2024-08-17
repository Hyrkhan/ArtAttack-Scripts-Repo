using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;

    public int attackDamage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("BossEnemy"))
        {
            if (other.GetComponent<EnemyScript>() != null)
            {
                other.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        rb.velocity = Vector2.right * speed;
    }
}
