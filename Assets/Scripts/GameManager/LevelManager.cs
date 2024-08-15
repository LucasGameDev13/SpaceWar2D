using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private float sceneLoadDelay;
    private AudioPlayer audioPlayer;
    private bool restartValue;

    //Method to go to the main menu of the game
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Method to loard the gameplay
    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad("GamePlay", sceneLoadDelay));
    }

    //Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    //Getting a delay when the play be selected
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
