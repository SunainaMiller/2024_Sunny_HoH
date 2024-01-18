using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelection : MonoBehaviour
{
    public List<AudioClip> music;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        SoundManager.Instance.PlaySound(music[0]);
        Debug.Log($"Looping music");
    }
}
