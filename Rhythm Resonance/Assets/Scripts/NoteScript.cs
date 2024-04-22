using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject goodEffect, greatEffect, perfectEffect, missEffect;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)) {
            if(canBePressed) {
                //GameManagerScript.instance.NoteHit();   // tells GameManager that we hit a note
                if(Mathf.Abs(transform.position.x) > -1.3) {
                    GameManagerScript.instance.GoodHit();
                    Instantiate(goodEffect, goodEffect.transform.position, goodEffect.transform.rotation, transform.parent.parent);                    
                    Debug.Log("Good");
                } else if(Mathf.Abs(transform.position.x) > -1.36) {
                    GameManagerScript.instance.GreatHit();
                    Instantiate(greatEffect, greatEffect.transform.position, greatEffect.transform.rotation, transform.parent.parent);
                    Debug.Log("Great");
                } else { //if(Mathf.Abs(transform.position.x) > -1.4) 
                    GameManagerScript.instance.PerfectHit();
                    Debug.Log("Perfect");
                    Instantiate(perfectEffect, perfectEffect.transform.position, perfectEffect.transform.rotation, transform.parent.parent);
                }
                gameObject.SetActive(false);            // deactivates note, deleting it when pressed
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {       // note can be pressed when it's in the trigger field (activator)
        if(other.tag == "Activator") {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {       // note canNOT be pressed after it exits the trigger field (activator)
        if(other.tag == "Activator") {
            canBePressed = false;
            if(gameObject.activeSelf) {         // checks if the note has not been deactivated, it's still active and therfore has been missed.
                GameManagerScript.instance.NoteMissed();
                Instantiate(missEffect, missEffect.transform.position, missEffect.transform.rotation, transform.parent.parent); 
            }
        }
    }
}
