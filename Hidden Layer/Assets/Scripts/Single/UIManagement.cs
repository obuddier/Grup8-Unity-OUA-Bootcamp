using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Çalýþtým oyun baþlamalý");
        SceneManager.LoadScene(1);
    }
}
