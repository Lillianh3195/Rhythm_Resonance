using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftNoteScript : MonoBehaviour
{
    public bool canBePressed;
    public GameObject note;
    // when the trigger hits the attached collider, canBePressed = true
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(note, transform.position, transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D other) {       // note can be pressed when it's in the trigger field (activator)
        if(other.tag == "Activator") {      
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {       // note canNOT be pressed after it exits the trigger field (activator)
        if(other.tag == "Activator") {
            canBePressed = false;
        }
    }
}
