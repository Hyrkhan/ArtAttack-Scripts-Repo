using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackScript : MonoBehaviour
{
    public Animator animator;
    public int attackdamage;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void isNear(int state)
    {
        switch (state)
        {
            case 1:
                animator.SetBool("Attack", true);
                animator.SetBool("Attack2", false);
                animator.SetBool("Attack3", false);
                break;
            case 2:
                animator.SetBool("Attack", false);
                animator.SetBool("Attack2", true);
                animator.SetBool("Attack3", false);
                break;
            case 3:
                animator.SetBool("Attack", false);
                animator.SetBool("Attack2", false);
                animator.SetBool("Attack3", true);
                break;
            case 4:
                animator.SetBool("Attack", false);
                animator.SetBool("Attack2", false);
                animator.SetBool("Attack3", false);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().TakeDamage(attackdamage);
        }
    }
}
