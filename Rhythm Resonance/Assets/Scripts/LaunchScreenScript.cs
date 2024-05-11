using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.EventSystems;
public class LaunchScreenScript : MonoBehaviour
{
    public GameObject ControlsPage;
    public GameObject MenuPage;
    public GameObject launchScreenMenuFirst;
    public GameObject controlsMenuFirst;


    // Start is called before the first frame update

    public void Start()
    {
        ControlsPage.SetActive(false);
        EventSystem.current.SetSelectedGameObject(launchScreenMenuFirst);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DisplayControls()
    {
        ControlsPage.SetActive(true);
        MenuPage.SetActive(false);
        EventSystem.current.SetSelectedGameObject(controlsMenuFirst);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoBack()
    {
        ControlsPage.SetActive(false);
        MenuPage.SetActive(true);
        EventSystem.current.SetSelectedGameObject(launchScreenMenuFirst);
    }
}
