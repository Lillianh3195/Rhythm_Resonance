using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BeatScrollerScript : MonoBehaviour
{
    public float beatTempo;     // standard is 120 bpm
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;        // how fast notes should move per second
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);  // notes move along x-axis        
    }
}
