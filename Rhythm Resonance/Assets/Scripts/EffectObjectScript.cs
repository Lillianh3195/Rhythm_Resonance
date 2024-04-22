using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObjectScript : MonoBehaviour
{
    public float lifetime = 0.2f;
    float t = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.localScale = new Vector3(Mathf.Lerp(1f, 2f, t/0.2f), Mathf.Lerp(1f, 2f, t/0.2f), 1);   // scales object from 1 to 2 over 0.2 seconds
        
        Destroy(gameObject, lifetime);
    }
}
