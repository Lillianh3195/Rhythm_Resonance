using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
The Conductor class is the main song managing class that will track the song
position and control synced actions. 
*/ 
public class ConductorScript : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm = 170;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //The offset to the first beat of the song in seconds
    // This accounts for the small period of silence before the song starts.
    public float firstBeatOffset;

    //Keeps an array of all the position-in-beats of notes in the song
    // Ex: {1f, 2f, 2.5f, 3f, 3.5f, 4.5f}
    public float[] notes;

    // The index of the next note to be spawned. Increment this whenever
    // a note is spawned.
    public int nextIndex = 0;

    public float beatsShownInAdvance = 0;

    public GameObject note;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    // Update is called once per frame and determines whether a note should be spawned
    void Update()
    {
    //determine how many seconds since the song started
    songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

    //determine how many beats since the song started
    songPositionInBeats = songPosition / secPerBeat;

    // Check if there are notes left in the song.
    // If there are notes left, we then see if the song reaches the beat where the next
    // note should be spawned.
    // beatsShownInAdvance: if current songPositionInBeats is 1 but beat 3 is spawned,
    // then 3 beats are shown in advance
    if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats + beatsShownInAdvance)
    {
        //Instantiate( /* Music Note Prefab */ );
        Instantiate(note, transform.position, transform.rotation);

        //initialize the fields of the music note

        nextIndex++;
    }

    // Mine
    /*
    if (Mathf.Floor(songPositionInBeats) > Mathf.Floor(songPositionInBeats - Time.deltaTime))
    {
        // Instantiate the note at the current position and rotation of the ConductorScript GameObject
        Instantiate(note, transform.position, transform.rotation);
        // Initialize the fields of the music note
    }
    */
    /*
    if(Input.GetKeyDown(keyToPress)) {
        Instantiate(note, transform.position, Quaternion.identity);
    }  
    */      
    }
    
}
