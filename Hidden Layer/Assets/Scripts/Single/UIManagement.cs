using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("�al��t�m oyun ba�lamal�");
        SceneManager.LoadScene(1);
    }
}
