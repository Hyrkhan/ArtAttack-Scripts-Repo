using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseScript : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    public float enemyDistance;
    public bool isPaused = false;
    public Animator animator;
    public int attackdamage;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && Vector2.Distance(transform.position, target.position) > enemyDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Attack", true);
        }
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().TakeDamage(attackdamage);
        }
    }
}

