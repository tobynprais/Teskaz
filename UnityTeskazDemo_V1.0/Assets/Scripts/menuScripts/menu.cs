using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject loadingScreen;
    public string sceneName;

    public void playGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }
    public void quitGame()
    {
        Debug.Log("This will quit the game, only works in actual build, not in Unity editor.");
        Application.Quit();
    }

}
