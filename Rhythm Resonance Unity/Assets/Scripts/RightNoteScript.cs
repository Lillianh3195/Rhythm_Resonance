using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightNoteScript : MonoBehaviour
{
    public bool canBeReleased;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {       // note can be pressed when it's in the trigger field (activator)
        if(other.tag == "Activator") {
            canBeReleased = true;
        }
    }
}
