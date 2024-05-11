using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwitchCamScript : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CameraManagerScript.SwitchCamera(cam1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CameraManagerScript.SwitchCamera(cam2);
        }
    }
}
