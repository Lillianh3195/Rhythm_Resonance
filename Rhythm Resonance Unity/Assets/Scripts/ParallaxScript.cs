using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour

{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update () {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); // how far we moved relative ot camera
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (cam.transform.position.x > startpos + length) startpos += length;
        else if (cam.transform.position.x < startpos - length) startpos -= length;
        //if (temp > startpos + length) startpos += length;
        //else if (temp < startpos - length) startpos -= length;
    }
}


/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public Camera cam;
    public Transform subject;
    Vector2 startPosition;   // even though this has 3 vectors (x, y, z), will only store x and y here
    float startZ;  // z position is a separate variable

    // properties: variables we calculate everytime we call them. Will use these variables in Update()
    Vector2 travel => (Vector2)cam.transform.position - startPosition;  // distance camera moved from starting position

    float clippingPlane => (cam.transform.position.z + (cam.transform.position.z > 0 ? cam.farClipPlane : cam.nearClipPlane));  //mine
    float parallaxFactor => Mathf.Abs(transform.position.z) / clippingPlane;  //mine
    //float distanceFromSubject => transform.position.z - subject.position.z;     // distance from subject;
    //float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    //float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;    // (x, y)   
        startZ = transform.position.z;  // z
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
*/
