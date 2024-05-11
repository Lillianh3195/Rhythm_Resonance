using System.Collections;
using System.Collections.Generic;
using Cinemachine;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


public class EffectObjectScript : MonoBehaviour
{
    public float lifetime = 0.1f;
    float t = 0f;  
    
    public UnityEngine.UI.Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {       
        t += Time.deltaTime;
        if (CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera.Name == "Virtual Camera 2") {
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        transform.localScale = new Vector3(Mathf.Lerp(1f, 1.5f, t/0.1f), Mathf.Lerp(1f, 1.5f, t/0.1f), 1);   // scales object from 1 to 2 over 0.1 seconds
        image.enabled = true;
        Destroy(gameObject, lifetime);  
    }
}
