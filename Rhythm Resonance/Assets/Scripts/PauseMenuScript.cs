using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuScript : MonoBehaviour
{
    // static cuz we don't want to reference this script, but check from other scripts if game is paused
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public string levelNum;
    public GameObject resumeFirst;

    // Update is called once per frame
    public void Start()
    {
        pauseMenuUI.SetActive(false);
        EventSystem.current.SetSelectedGameObject(resumeFirst);
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;    // time passes at a normal rate
        gameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;    // freezes the game
        gameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading menu...");
    }

    public void Retry() {
        Time.timeScale = 1;
        gameIsPaused = false;
        string sceneName = "Level" + levelNum;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Retry...");
    }
}
