using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRegisterScript : MonoBehaviour
{
    
    private void OnEnable()
    {
        CameraManagerScript.Register(GetComponent<CinemachineVirtualCamera>());
    }
    private void OnDisable()
    {
        CameraManagerScript.Unregister(GetComponent<CinemachineVirtualCamera>());
    }
}



