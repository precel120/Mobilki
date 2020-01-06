using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    public GameObject Play;
    public void openLevelChoice()
    {
        MainMenu.SetActive(false);
        Play.SetActive(true);
    }

    public void playLevel(int number)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + number);
    }

    public void openCredits()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void goBack()
    {
        Play.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void closeCredits()
    {
        Credits.SetActive(false);
        MainMenu.SetActive(true);
    }
}
