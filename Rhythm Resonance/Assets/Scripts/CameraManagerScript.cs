using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManagerScript : MonoBehaviour
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;
    public  Camera twoDimensionalCamera;
    public  Camera threeDimensionalCamera;

    void Awake()
    {
        twoDimensionalCamera.enabled = true;
        threeDimensionalCamera.enabled = false;
    }

    void Update()
    {     
        if (Input.GetKeyDown(KeyCode.R))
        {
            ShowThreeDimensionalView();
        } 
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ShowTwoDimensionalView();        
        }    
    }
    public void ShowTwoDimensionalView() {
        threeDimensionalCamera.enabled = false;
        twoDimensionalCamera.enabled = true;
    }
    
    public void ShowThreeDimensionalView() {
        threeDimensionalCamera.enabled = true;
        twoDimensionalCamera.enabled = false;
    }

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera newCamera)
    {
        newCamera.Priority = 10;
        ActiveCamera = newCamera;

        foreach(CinemachineVirtualCamera cam in cameras)
        {
            if (cam != newCamera)
            {
                cam.Priority = 0;
            }
        }
    }
    public static void Register(CinemachineVirtualCamera camera) 
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }
}