using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTracker : MonoBehaviour
{
    public static CoinTracker instance;
    public TMP_Text cointext;
    public int currentcoins = 0;

    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        cointext.text = "Coins: " + currentcoins.ToString();
    }

    public void IncreasingCoins(int value)
    {
        currentcoins += value;
        cointext.text = "Coins: " + currentcoins.ToString();
    }
    public void DecreaseCoin(int expense)
    {
        currentcoins -= expense;
        cointext.text = "Coins: " + currentcoins.ToString();
    }
}
