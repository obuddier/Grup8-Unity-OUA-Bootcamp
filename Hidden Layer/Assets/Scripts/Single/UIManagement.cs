using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using KeySystem;

public class UIManagement : MonoBehaviour
{
    public GameObject gameOverPanel;
    public KeyRaycast keyRaycast;
    public GameObject howToPlayPanel;
    public GameObject gameName;


    private void Update()
    {
        if (keyRaycast.ParchmentCount == 5)
        {
            Debug.Log("Oyun bitti knk");
            GameOver();
        }
    }

    public void StartGame()
    {
        Debug.Log("Çalýþtým oyun baþlamalý");
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HowToPlayPanel()
    {
        howToPlayPanel.SetActive(true);
        gameName.SetActive(false);
    }

    public void ClosePanel()
    { 
        howToPlayPanel.SetActive(false);
        gameName.SetActive(true);
    }
}
