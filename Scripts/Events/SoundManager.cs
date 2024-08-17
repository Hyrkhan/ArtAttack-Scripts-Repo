using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool isMuted = false;
      
    public void ToggleMute()
    {
        isMuted = !isMuted;

        // Adjust audio volume based on the mute state
        AudioListener.volume = isMuted ? 0 : 1;
    }
}
