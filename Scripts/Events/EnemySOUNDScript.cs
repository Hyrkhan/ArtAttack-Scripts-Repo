using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySOUNDScript : MonoBehaviour
{
    public AudioSource WalkSound;
    private float soundTimer = 0.0f;
    private float soundInterval = 0.4f;

    void Start()
    {
        // Set the WalkSound to loop
        WalkSound.loop = true;
    }

    void Update()
    {
        // Increment the timer by the time elapsed since the last frame
        soundTimer += Time.deltaTime;

        // Check if the soundTimer has exceeded the soundInterval
        if (soundTimer >= soundInterval)
        {
            // Play the walk sound
            WalkSound.Play();

            // Reset the timer
            soundTimer = 0.0f;
        }
    }

}
