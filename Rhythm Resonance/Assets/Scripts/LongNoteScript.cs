using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LongNoteScript : MonoBehaviour
{
    public GameObject longNote;
    public KeyCode keyToPress;

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("LongNote"))
        { 
            longNote = other.gameObject;
            if (Input.GetKey(keyToPress))
            {
                longNote.SetActive(false);
            }
        }
    }
}
