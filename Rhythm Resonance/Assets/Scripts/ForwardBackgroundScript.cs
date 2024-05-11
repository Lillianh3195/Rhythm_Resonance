using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
//using UnityEditor.Recorder;
using UnityEngine;

public class ForwardBackgroundScript : MonoBehaviour
{
    float singleTextureWidth;

    public float moveSpeed;

    void Start() 
    {
        SetupTexture();
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(-delta, 0, 0);
    }

    void CheckReset()
    {
        if (transform.position.x < -singleTextureWidth)
        {
            float newXPosition = transform.position.x + 2f * singleTextureWidth;
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
            //Debug.Log("Reset at " + transform.position); 
        }
    }

    void Update()
    {
        Scroll();
        CheckReset();
    }

}

