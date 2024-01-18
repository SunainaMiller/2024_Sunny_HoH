using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightswitchBehaviour : MonoBehaviour
{
    Image image;
    public Sprite lightswitchOn;
    public Sprite lightswitchOff;
    bool isLightOn;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = lightswitchOff;
    }
    public void LightswitchChange()
    {
        if(isLightOn)
        {
            image.sprite = lightswitchOff; // if light is on, switch it off
            isLightOn = false;
            SoundEffectSelection.Instance.PlayRandomLightswitchOff();
        }
        else
        {
            image.sprite = lightswitchOn;
            isLightOn = true;
            SoundEffectSelection.Instance.PlayRandomLightswitchOn();
        }
    }
}
