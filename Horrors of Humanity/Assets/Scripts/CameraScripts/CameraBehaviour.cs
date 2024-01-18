using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
    Vector3 startPos = new Vector3(0, 0, -11);
    public float scrollSpeed;
    public Camera ZoomCam;
    public float FOV;
    public float fovMin;
    public float fovMax;
    public Slider mouseScrollSensSlider;

    public static CameraBehaviour instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        transform.position = startPos;
        ZoomCam.fieldOfView = FOV;
        mouseScrollSensSlider.value = scrollSpeed; // at the beginning, the slider should represent the sens already
    }

    void Update()
    {
        

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomCam.fieldOfView -= scrollSpeed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomCam.fieldOfView += scrollSpeed;
        }

        ZoomCam.fieldOfView = Mathf.Clamp(ZoomCam.fieldOfView, fovMin, fovMax);
    }

    public void FOVChange()
    {
        scrollSpeed = mouseScrollSensSlider.value; // change scroll sens to slider's value
    }
}
