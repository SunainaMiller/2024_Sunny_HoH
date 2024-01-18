using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PPPManager : MonoBehaviour
{
    public static PPPManager instance;
    Volume volume;
    public VolumeProfile currentProfile; //, mainMenuProfile, day1Profile, day2Profile, day3Profile, oppositeApartmentProfile;

    private void Awake()
    {
        //we first declare the singleton
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile = currentProfile; // assigning profile
    }
}
