using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioSource musicSource, effectsSource;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
        Debug.Log($"Playing audio clip/sound effect");
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
        Debug.Log($"Changing master volume");
    }
}
