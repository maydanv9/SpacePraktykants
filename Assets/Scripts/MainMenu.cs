using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void GoBack1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex  -1);
    }
    public void GoBack2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Clicked?");
    }
}

