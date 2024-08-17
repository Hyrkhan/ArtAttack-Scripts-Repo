using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CharactersScene()
    {
        SceneManager.LoadScene("CharactersScene");
    }
    public void EnemiesScene()
    {
        SceneManager.LoadScene("Enemies");
    }
}
