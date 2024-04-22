using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteMakerScript : MonoBehaviour
{
    public KeyCode keyToPress;
    public GameObject note;
    public bool createMode;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                Instantiate(note, transform.position, Quaternion.identity);
            }
        }
    }
    }