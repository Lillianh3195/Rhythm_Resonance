using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    public GameObject goodEffect, greatEffect, perfectEffect, missEffect;

    public float beatTempo;    

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = 170;  // CHAGE IT BACK TO 170!!!  MUST SET it here so that each instantiation is the same
        beatTempo = beatTempo / 60f;        // how fast notes should move per second
        //Debug.Log(transform.parent.name);
        //Debug.Log(transform.parent.parent.name);
        //Debug.Log(transform.parent.parent.parent.name);
    }

    // Update is called once per frame
    void Update()
    {
        // Move notes left
        transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);  // notes move along x-axis
        /*
        if(Input.GetKeyDown(keyToPress)) {
            if(canBePressed) {
                //GameManagerScript.instance.NoteHit();   // tells GameManager that we hit a note
                if(Mathf.Abs(transform.position.x) > -1.3) {
                    GameManagerScript.instance.GoodHit();
                    Instantiate(goodEffect, goodEffect.transform.position, goodEffect.transform.rotation); //, transform.parent.parent.parent);    // need transform.parent.parent!!! if general note outside "Note folder"                
                    Debug.Log("Good");
                    
                } else if(Mathf.Abs(transform.position.x) > -1.36) {
                    GameManagerScript.instance.GreatHit();
                    Instantiate(greatEffect, greatEffect.transform.position, greatEffect.transform.rotation); //, transform.parent.parent.parent);
                    Debug.Log("Great");
                } else { //if(Mathf.Abs(transform.position.x) > -1.4) 
                    GameManagerScript.instance.PerfectHit();
                    Debug.Log("Perfect");
                    Instantiate(perfectEffect, perfectEffect.transform.position, perfectEffect.transform.rotation); //, transform.parent.parent.parent);
                }
                //Debug.Log(transform.parent.parent.name); 
                //gameObject.SetActive(false);            // deactivates note, deleting it when pressed 
                //Destroy(gameObject);         // does same thing as Destroy(this.gameObject)        
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D other) {       // note can be pressed when it's in the trigger field (activator)
        if(other.tag == "Activator") {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {       // note canNOT be pressed after it exits the trigger field (activator)
        if(other.tag == "Activator") {
            canBePressed = false;
            /*
            if(gameObject.activeSelf) {         // checks if the note has not been deactivated, it's still active and therfore has been missed.
                GameManagerScript.instance.NoteMissed();
                Instantiate(missEffect, missEffect.transform.position, missEffect.transform.rotation); //, transform.parent.parent.parent); 
                Debug.Log("Missed");
            }
            */
        }
    }
}
