using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public int coinvalue = 0;

    public HealthBarScript healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentHealth <= 0)
        {
            Die();
            CoinReward(coinvalue);
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        EnemyChaseScript enemyChaseScript = GetComponent<EnemyChaseScript>();
        if (enemyChaseScript != null)
        {
            // Pause the enemy's movement
            enemyChaseScript.Pause();

            // Pause the enemy for 0.2 seconds
            StartCoroutine(PauseForSeconds(0.2f));
        }
    }


    IEnumerator PauseForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Resume the enemy's movement
        GetComponent<EnemyChaseScript>().Resume();
    }

    void Die()
    {
        if (gameObject.CompareTag("BossEnemy"))
        {
            GameObject foothold = GameObject.FindGameObjectWithTag("Foothold");
            if (foothold != null)
            {
                Destroy(foothold);
            }
            SceneManager.LoadScene("CongratsScene");
        }

        Destroy(gameObject);
    }

    void CoinReward(int value)
    {
        CoinTracker.instance.IncreasingCoins(value);
    }
    

}
