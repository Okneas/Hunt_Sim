using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Camera mainCam;
    public Image img;
    Color alph;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mainCamera.sensivity = 2f;
            alph.a = 1;
            img.color = alph;
            mainCam.fieldOfView = 20;
            mainCam.nearClipPlane = 0.45f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            mainCamera.sensivity = 5f;
            alph.a = 0;
            img.color = alph;
            mainCam.fieldOfView = 69;
            mainCam.nearClipPlane = 0.01f;
        }
    }
}
