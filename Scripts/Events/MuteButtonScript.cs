using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour
{
    public SoundManager soundManager;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(soundManager.ToggleMute);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
