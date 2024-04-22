
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerScript : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    public GameObject note;
    bool active = false;
    public GameObject goodEffect, greatEffect, perfectEffect, missEffect;

    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;            
            if (active) {    
                Debug.Log("Before: " + note.transform.position.x);            
                if (note.transform.position.x == -1.066) {
                    GameManagerScript.instance.PerfectHit();
                    Debug.Log("Perfect");
                    Instantiate(perfectEffect, perfectEffect.transform.position, perfectEffect.transform.rotation);
                } 
                else if(note.transform.position.x > -1.45 && note.transform.position.x < -1.35) {
                    GameManagerScript.instance.GreatHit();
                    if (hitEffect) {
                        Destroy(hitEffect);
                        Debug.Log("Destroyed hitEffect!");
                    }
                    hitEffect = Instantiate(greatEffect, greatEffect.transform.position, greatEffect.transform.rotation); 
                    Debug.Log("Great");
                }
                else if(note.transform.position.x > -1.55 && note.transform.position.x < -1.2 ) {
                    GameManagerScript.instance.GoodHit();
                    if (hitEffect) {
                        Destroy(hitEffect);
                        Debug.Log("Destroyed hitEffect!");
                    }
                    hitEffect = Instantiate(goodEffect, goodEffect.transform.position, goodEffect.transform.rotation);                 
                    Debug.Log("Good");   
                }        
                Debug.Log("After" + note.transform.position.x);
                note.SetActive(false);   // MUST deactivate note so that MissEffect does not show
                Destroy(note); 
                active = false;
                Debug.Log("Destroyed note!");                
            }
            
        }
        if (Input.GetKeyUp(keyToPress))
        {    
            theSR.sprite = defaultImage;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        active = true;
        if(other.CompareTag("Note")) {
            note = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        active = false; 
        if (note.activeSelf) {        
            GameManagerScript.instance.NoteMissed();
            if (hitEffect) {
                Destroy(hitEffect);
                Debug.Log("Destroyed hitEffect!");
            }
            hitEffect = Instantiate(missEffect, missEffect.transform.position, missEffect.transform.rotation); //, transform.parent.parent.parent); 
            Debug.Log("Missed");
        }
                
    }    
}

    





/*sing UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using UnityEditor.Timeline.Actions;

public class ButtonControllerScript : MonoBehaviour {
    public SpriteRenderer sr;
    public KeyCode keyToPress;
    bool active = false;
    GameObject note;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public bool createMode;

    void Awake() {
    sr = GetComponent<SpriteRenderer>();
}

void Start() {
    sr.sprite = defaultImage;
}

void Update() {
    if(Input.GetKeyDown(keyToPress)) {
        StartCoroutine(Pressed());
    }
    if(Input.GetKeyDown(keyToPress) && active) {
        Destroy(note);
        active = false;
    }

    
}

void OnTriggerEnter2D(Collider2D other) {
    active = true;
    if(other.tag == "Note") {
        note = other.gameObject;
    }
}

void OnTriggerExit2D(Collider2D other) {
    active = false;
}

IEnumerator Pressed() {
    sr.sprite = pressedImage;
    yield return new WaitForSeconds(0.05f);
    sr.sprite = defaultImage;
}
}
*/




