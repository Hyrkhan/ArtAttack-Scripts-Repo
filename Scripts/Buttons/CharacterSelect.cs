using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public AudioSource BackSound;
    
    public void BacktoMainMenu()
    {
        BackSound.Play();
        SceneManager.LoadScene("TitleScreen");
    }
    public void ScifiElfCharacter()
    {
        SceneManager.LoadScene("ScifiELF");
    }
    public void BacktoCharactersScene()
    {
        SceneManager.LoadScene("CharactersScene");
    }
    public void BacktoEnemiesScene()
    {
        SceneManager.LoadScene("Enemies");
    }
    public void OctoMob()
    {
        SceneManager.LoadScene("OctoMob");
    }
    public void CrossMouth()
    {
        SceneManager.LoadScene("CrossMouth");
    }
    public void AUSRA()
    {
        SceneManager.LoadScene("AUSRA");
    }
}
