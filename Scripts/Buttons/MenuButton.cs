using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public GameObject mainscreen;
    public GameObject menuscreen;
    public static bool isPaused = false;

    public AudioSource ButtonClickSound;
    public AudioSource ButtonClickSound2;

    public void Menu()
    {
        ButtonClickSound.Play();
        mainscreen.SetActive(false);
        menuscreen.SetActive(true);
        isPaused = true;
    }
    public void Back()
    {
        ButtonClickSound2.Play();
        mainscreen.SetActive(true);
        menuscreen.SetActive(false);
        isPaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        isPaused = false;
    }
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPaused = false;   
    }
    public void BacktoGameScene()
    {
        SceneManager.LoadScene("GameScene");
        mainscreen.SetActive(true);
        menuscreen.SetActive(false);
        isPaused = false;
    }
    public void SkillsScene()
    {
        SceneManager.LoadScene("ScifiELFSkills");
    }

    public void SkillsAttack()
    {
        SceneManager.LoadScene("ScifiELFAttack");
    }

    public void Skill1()
    {
        SceneManager.LoadScene("ScifiELFSkill1");
    }
    public void Guarding()
    {
        SceneManager.LoadScene("ScifiELFGuarding");
    }

    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
