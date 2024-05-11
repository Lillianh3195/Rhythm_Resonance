using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BackgroundManagerScript : MonoBehaviour
{
    public GameObject threeDimensionalBackground;

    public GameObject twoDimensionalBackground;

    void Update()
    {
        CinemachineBrain activeBrain = CinemachineCore.Instance.GetActiveBrain(0);

        if (activeBrain != null && activeBrain.ActiveVirtualCamera != null) {
            if (activeBrain.ActiveVirtualCamera.Name == "Virtual Camera 2")
            {
                threeDimensionalBackground.SetActive(true);
                twoDimensionalBackground.SetActive(false);
            }
            else {
                threeDimensionalBackground.SetActive(false);
                twoDimensionalBackground.SetActive(true);
            }
        }
    }
}
