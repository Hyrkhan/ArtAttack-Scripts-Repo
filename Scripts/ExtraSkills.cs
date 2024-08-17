using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSkills : MonoBehaviour
{
    public int recovery;

    public AudioSource BuyHealthAudio;
    public AudioSource IncreaseAttackAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyHealthRec()
    {
        PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        CoinTracker coinTracker = GameObject.Find("EventSystem").GetComponent<CoinTracker>();
        int currentcoin = coinTracker.currentcoins;

        if (currentcoin >= 20)
        {
            BuyHealthAudio.Play();
            playerMovement.BuyHealth(recovery);
            coinTracker.DecreaseCoin(20);
        }
    }

    public void IncreaseAttackDamage()
    {
        CombatScript combatScript = GameObject.Find("Player").GetComponent<CombatScript>();
        CoinTracker coinTracker = GameObject.Find("EventSystem").GetComponent<CoinTracker>();
        int currentcoin = coinTracker.currentcoins;

        if (currentcoin >= 50)
        {
            IncreaseAttackAudio.Play();
            combatScript.IncreaseAttack(2);
            coinTracker.DecreaseCoin(50);
        }


    }

}
