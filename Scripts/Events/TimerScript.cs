using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timertext;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countdown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerlimit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countdown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
    /*
        if(hasLimit && ((countdown && currentTime <= timerlimit) || (!countdown && currentTime >= timerlimit)))
        {
            currentTime = timerlimit;
            SetTimerText();
            timertext.color = Color.red;
            enabled = false;
        }
    */
        SetTimerText();
        
    }
    void SetTimerText()
    {
        timertext.text = currentTime.ToString("0.00");
    }
}
