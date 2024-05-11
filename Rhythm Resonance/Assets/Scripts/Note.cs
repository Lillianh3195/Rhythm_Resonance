using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;

    public int longNoteIndex;
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();        
    }

    // Update is called once per frame
    // MUST be fixed update in order to be paused
    void FixedUpdate()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        // Clamp t to ensure it never exceeds 1. This ensure that the note object is not rendered beyond its lifetime.
        t = Mathf.Clamp01(t);
        if (t >= 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.right * SongManager.Instance.noteSpawnX, Vector3.right * SongManager.Instance.noteDespawnX, t); 
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}