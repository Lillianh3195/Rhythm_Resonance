using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoScript : MonoBehaviour
{
    public GameObject bar;
    public float spawnRate = 2.8f; //2.8f;
    private float timer = 0;
    private float delay = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (timer < delay) {
            timer += Time.deltaTime;
        } else {
            spawnBar();
            timer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            spawnBar();
            timer = 0;
        }
    }

    void spawnBar() {
        Instantiate(bar, transform.position, transform.rotation);
    }
}
