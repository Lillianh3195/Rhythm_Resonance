
using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonControllerScript : MonoBehaviour
{
    public CameraManagerScript cameraManager;
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    private GameObject note;
    private GameObject longNote;
    bool active = false;
    public GameObject goodEffect, greatEffect, perfectEffect, missEffect;
    public GameObject hitEffect;
    public static int index;
    public static ButtonControllerScript Instance;
    public bool canBePressed = false;
    public bool missedLongNote = false;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;

            if (active && note != null)
            {
                DisplayHitEffect(note);
                note.SetActive(false);   // MUST deactivate note so that MissEffect does not show
                Destroy(note);
                active = false;
                //Debug.Log("Destroyed note!");  
            }
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
            canBePressed = false;
        }
    }

    public void DisplayHitEffect(GameObject noteType)
    {
        if (Math.Abs(noteType.transform.localPosition.x) < 0.05)
        {
            hitEffect = Instantiate(perfectEffect, transform);
            ScoreManager.Hit();
            ScoreManager.Instance.PerfectHit();
            //Debug.Log("PERFECT");
        }

        else if (Math.Abs(noteType.transform.localPosition.x) < 0.2)
        {
            hitEffect = Instantiate(greatEffect, transform);
            ScoreManager.Hit();
            ScoreManager.Instance.GreatHit();
            //Debug.Log("GREAT");
        }
        else if (Math.Abs(noteType.transform.localPosition.x) < 0.35)
        {
            hitEffect = Instantiate(goodEffect, transform);
            ScoreManager.Hit();
            ScoreManager.Instance.GoodHit();
            //Debug.Log("GOOD");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        active = true;
        if (other.CompareTag("Note"))
        {
            note = other.gameObject;
            if (hitEffect)
            {
                Destroy(hitEffect);
                //hitEffect.SetActive(false);
                //Debug.Log("DESTROYED HIT EFFECT!");
            }
        }

        else if (other.CompareTag("LongNote"))
        {
            longNote = other.gameObject;
            if (Input.GetKey(keyToPress))
            {
                // Check if it's a new long note
                if (index != Lane.longSpawnIndex)
                {
                    missedLongNote = false;
                    //Debug.Log("New long note!");
                    //Debug.Log(longNote.transform.localPosition.x);
                    DisplayHitEffect(longNote);
                    //Debug.Log("Index:" + index + "LongSpawnIndex: " + Lane.longSpawnIndex);
                    index = Lane.longSpawnIndex;
                }
                else
                {
                    ScoreManager.Instance.LongHit();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

        active = false;
        if (note != null && note.activeSelf)
        {
            ScoreManager.Miss();
            hitEffect = Instantiate(missEffect, transform);
            //print($"Missed {Lane.Instance.inputIndex} note");
            Lane.Instance.inputIndex++;
        }
        
        if (longNote != null && longNote.activeSelf)
        {
            //Debug.Log("Index " + index + " LongSpawnIndex " + Lane.longSpawnIndex);
            if (!missedLongNote) {
                missedLongNote = true;
                ScoreManager.Miss();
                hitEffect = Instantiate(missEffect, transform);
            }           
        }
    }
}











