using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CeilingLightBehaviour : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite lightOn;
    public Sprite lightOff;
    bool isLightOn;
    public GameObject lightGradient;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = lightOff;
        lightGradient.SetActive(false);
    }
    public void LightChange()
    {
        if (isLightOn) // if the light is on, switch it off
        {
            ChangeLightOff();
        }
        else
        {
            ChangeLightOn(); // if the light is off, switch it on
        }
    }
    void ChangeLightOn()
    {
        sr.sprite = lightOn;
        lightGradient.SetActive(true);
        isLightOn = true;
    }
    void ChangeLightOff()
    {
        sr.sprite = lightOff;
        lightGradient.SetActive(false);
        isLightOn = false;
    }
}
