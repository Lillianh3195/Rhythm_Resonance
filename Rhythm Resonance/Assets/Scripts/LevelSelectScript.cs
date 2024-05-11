using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class LevelSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");   // async does not load notes or music
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void StartLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
}
