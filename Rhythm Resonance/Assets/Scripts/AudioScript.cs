using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    public float delayInSeconds = 4.0f;
    //Value from the slider, and it converts to volume level
    float slider = 0.1f;
        
    void Start()
    {
        audioSource.PlayDelayed(delayInSeconds); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        //Create a horizontal Slider that controls volume levels. Its highest value is 1 and lowest is 0
        slider = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), slider, 0.0F, 1.0F);
        //Makes the volume of the Audio match the Slider value
        audioSource.volume = slider;
    }
}
