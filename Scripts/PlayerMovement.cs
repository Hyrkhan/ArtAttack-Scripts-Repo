using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;

    public float speed = 10f;
    public int jumpforce = 10;
    public float delay = 1f;

    public int maxHealth = 20;
    public int currentHealth;
    public HealthBarScript healthBar;

    bool hasJumped = false;
    public bool skillActive = false;

    bool guarding;
    public AudioSource GuardingSound;

    float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        guarding = animator.GetBool("Guarding");
        if (!MenuButton.isPaused)
        {
            if (!skillActive)
            {
                if(CrossPlatformInputManager.GetButton("LEFT"))
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    animator.SetFloat("Speed", -speed);
                }
                else if (CrossPlatformInputManager.GetButton("RIGHT"))
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    animator.SetFloat("Speed", speed);
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    animator.SetFloat("Speed", 0);
                }
                if (!hasJumped && CrossPlatformInputManager.GetButton("Jump"))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                    hasJumped = true;
                }

                /*
                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    animator.SetFloat("Speed", -speed);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    animator.SetFloat("Speed", speed);
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    animator.SetFloat("Speed", 0);
                }

                if (!hasJumped && Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                    hasJumped = true;
                    animator.SetBool("isJumping", true);
                }
                */
                
            }
            if (hasJumped)
            {
                timer += Time.deltaTime;
            }

            if (timer >= delay)
            {
                rb.AddForce(new Vector2(0, -jumpforce), ForceMode2D.Impulse);
                timer = 0f;
            }
            if (skillActive)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if ((collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Foothold") && rb.velocity.y <= 0.0f)
            {
                hasJumped = false;
            }

        if (collision.gameObject.tag == "Enemy")
            {
                TakeDamage(10);
            }
            if (collision.gameObject.tag == "BossEnemy")
            {
                TakeDamage(10);
            }
        }
        public void TakeDamage(int damage)
        {
            if (guarding)
            {
                GuardingSound.Play();
                damage = 0;
            }
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {   
                SceneManager.LoadScene("GameOverScene");
            }
        }

    public void BuyHealth(int recovery)
    {
        currentHealth += recovery;
        healthBar.SetHealth(currentHealth);
    }

    public void SetSkillActive(bool active)
        {
            skillActive = active;
        }
}

