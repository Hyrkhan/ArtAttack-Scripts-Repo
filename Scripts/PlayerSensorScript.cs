using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensorScript : MonoBehaviour
{
    public GameObject parentObject;
    private float timesincelastattacked = 0f;
    public float cooldowntime = 4f;
    private int attackanimation = 1;
    private bool isPlayerInside = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInside)
        {
            timesincelastattacked += Time.deltaTime;

            if (timesincelastattacked >= cooldowntime)
            {
                switch (attackanimation)
                {
                    case 1:
                        parentObject.GetComponent<BossAttackScript>().isNear(1);
                        timesincelastattacked = 0f;
                        cooldowntime = 4f; // reset cooldown time
                        attackanimation = 2;
                        StartCoroutine(DelayedIsNear(4, 1.14f));
                        break;
                    case 2:
                        parentObject.GetComponent<BossAttackScript>().isNear(2);
                        timesincelastattacked = 0f;
                        cooldowntime = 4f; // reset cooldown time
                        attackanimation = 3;
                        StartCoroutine(DelayedIsNear(4, 1.3f));
                        break;
                    case 3:
                        parentObject.GetComponent<BossAttackScript>().isNear(3);
                        timesincelastattacked = 0f;
                        cooldowntime = 4f; // reset cooldown time
                        attackanimation = 1;
                        StartCoroutine(DelayedIsNear(4, 1.42f));
                        break;
                }
                timesincelastattacked = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    IEnumerator DelayedIsNear(int value, float delay)
    {
        yield return new WaitForSeconds(delay);
        parentObject.GetComponent<BossAttackScript>().isNear(value);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;
            parentObject.GetComponent<BossAttackScript>().isNear(4);
            StopAllCoroutines();
            timesincelastattacked = 0f;
            attackanimation = 1;
        }
    }
}
