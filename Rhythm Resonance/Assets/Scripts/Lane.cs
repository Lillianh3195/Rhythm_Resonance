using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;

    public GameObject longNotePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();    // in seconds

    public List<double> startTimeStamps = new List<double>();
    public List<double> endTimeStamps = new List<double>();
    public int spawnIndex = 0;
    public int inputIndex = 0;
    public int startLongSpawnIndex = 0;
    public int endLongSpawnIndex = 0;
    public static Lane Instance;
    public float noteVelocity = 0.5f;
    public float spawnInterval;
    public static int longSpawnIndex;

    public static int numOfMiddleNotes;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        spawnInterval = 1.0f / noteVelocity;
        //Debug.Log("Tempo Map " + SongManager.midiFile.GetTempoMap());
        //Debug.Log("Timed Event " + SongManager.midiFile.GetTimedEvents());
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {    
                // Add timestamps for when a note should be generated for each lane  
                if (note.Length <= 32) {         
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
                //Debug.Log("NOTE LENGTH " + note.Length);
                
                //Debug.Log(SongManager.midiFile.GetDuration());

                } else { // (note.Length > 32) 
                    // Get start and end timestamps for long notes
                    var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                    startTimeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
                    //endTimeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);

                    var endTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.EndTime, SongManager.midiFile.GetTempoMap());
                    endTimeStamps.Add((double)endTimeSpan.Minutes * 60f + endTimeSpan.Seconds + (double)endTimeSpan.Milliseconds / 1000f);
                }
            } 
        }
    }

    // Update is called once per frame
    void Update()
    {  
        
        // Spawn long notes when their end time is reached (end time includes start and end time of long note)        
        if (endLongSpawnIndex < endTimeStamps.Count && startLongSpawnIndex < startTimeStamps.Count) 
        {
            double currentTime = SongManager.GetAudioSourceTime();
            double startTime = startTimeStamps[startLongSpawnIndex];
            double endTime = endTimeStamps[endLongSpawnIndex];

            // mine
            
            if (currentTime >= startTime - SongManager.Instance.noteTime)
            {
                double noteDuration = endTime - startTime;
                float numberOfNotes = (float)noteDuration / SongManager.Instance.noteTime;
                numOfMiddleNotes += (int)numberOfNotes;
                var longNote = Instantiate(longNotePrefab, transform);                
                longNote.transform.localScale = new Vector3(0.2f, longNote.transform.localScale.y, longNote.transform.localScale.z);
                
            }
            
            // Check if the current time is at the end of the long note
            if (currentTime >= endTime - SongManager.Instance.noteTime)
            {
                //var longNote = Instantiate(longNotePrefab, transform);
                //notes.Add(longNote.GetComponent<Note>());
                //longNote.GetComponent<Note>().assignedTime = (float)endTime;
                
                longSpawnIndex++;
                startLongSpawnIndex++;
                //Debug.Log("LONG SPAWN INDEX " + longSpawnIndex);
                endLongSpawnIndex++;
            }
            
        }

        if (spawnIndex < timeStamps.Count)
        {
            
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);                
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
                //Debug.Log("Spawn Index: " + spawnIndex);               
            }
        }        
    }          
    
    void Hit()
    {        
        ScoreManager.Hit();
    }
    void Miss()
    {
        ScoreManager.Miss();
    }
        
}    
