using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSelection : MonoBehaviour
{
    // muster
    /*public List<AudioClip> soundEffects;
    int soundInList; // number in list
    int previousSoundInList;*/

    #region Lists
    public List<AudioClip> circlingEffects;
    int numberInList; // number in list
    int previousNumberInList;

    public List<AudioClip> drawingEffects;
    int drawingSoundInList;
    int previousDrawingSoundInList;

    public List<AudioClip> paperRustlingEffects;
    int paperRustlingInList;
    int previousPaperRustlingInList;

    public List<AudioClip> pageTurningEffects;
    int pageTurningInList;
    int previousPageTurningInList;

    public List<AudioClip> fabricRustlingEffects;
    int fabricRustlingInList;
    int previousFabricRustlingInList;

    public List<AudioClip> walkingQuietEffects;
    int walkingQuietInList;
    int previousWalkingQuietInList;

    public List<AudioClip> walkingLoudEffects;
    int walkingLoudInList;
    int previousWalkingLoudInList;

    public List<AudioClip> lightswitchOnEffects;
    int lightswitchOnInList;
    int previousLightswitchOnInList;

    public List<AudioClip> lightswitchOffEffects;
    int lightswitchOffInList;
    int previousLightswitchOffInList;
    #endregion

    public static SoundEffectSelection Instance;
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

    #region Muster
    /*public void PlayRandomClip()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        soundInList = Random.Range(0, soundEffects.Count); // roll new number
        if (soundInList == previousSoundInList) // if new number is same as previous number, reroll again
        {
            soundInList = Random.Range(0, soundEffects.Count);
        }
        SoundManager.Instance.PlaySound(soundEffects[soundInList]);
        Debug.Log($"Playing sound effect number {soundInList}");
        previousSoundInList = soundInList;
    }*/
    #endregion

    public void PlayRandomCircling()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        numberInList = Random.Range(0, circlingEffects.Count); // roll new number
        if (numberInList == previousNumberInList) // if new number is same as previous number, reroll again
        {
            numberInList = Random.Range(0, circlingEffects.Count);
        }
        SoundManager.Instance.PlaySound(circlingEffects[numberInList]);
        Debug.Log($"Playing sound effect number {numberInList}");
        previousNumberInList = numberInList;
    }

    public void PlayRandomDrawing()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        drawingSoundInList = Random.Range(0, drawingEffects.Count); // roll new number
        if (drawingSoundInList == previousNumberInList) // if new number is same as previous number, reroll again
        {
            drawingSoundInList = Random.Range(0, drawingEffects.Count);
        }
        SoundManager.Instance.PlaySound(drawingEffects[drawingSoundInList]);
        Debug.Log($"Playing sound effect number {drawingSoundInList}");
        previousDrawingSoundInList = drawingSoundInList;
    }

    public void PlayRandomPaperRustling()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        paperRustlingInList = Random.Range(0, paperRustlingEffects.Count); // roll new number
        if (paperRustlingInList == previousNumberInList) // if new number is same as previous number, reroll again
        {
            paperRustlingInList = Random.Range(0, paperRustlingEffects.Count);
        }
        SoundManager.Instance.PlaySound(paperRustlingEffects[paperRustlingInList]);
        Debug.Log($"Playing sound effect number {paperRustlingInList}");
        previousPaperRustlingInList = paperRustlingInList;
    }

    public void PlayRandomPageTurning()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        pageTurningInList = Random.Range(0, pageTurningEffects.Count); // roll new number
        if (pageTurningInList == previousPageTurningInList) // if new number is same as previous number, reroll again
        {
            pageTurningInList = Random.Range(0, pageTurningEffects.Count);
        }
        SoundManager.Instance.PlaySound(pageTurningEffects[pageTurningInList]);
        Debug.Log($"Playing sound effect number {pageTurningInList}");
        previousPageTurningInList = pageTurningInList;
    }

    public void PlayRandomFabricRustling()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        fabricRustlingInList = Random.Range(0, fabricRustlingEffects.Count); // roll new number
        if (fabricRustlingInList == previousFabricRustlingInList) // if new number is same as previous number, reroll again
        {
            fabricRustlingInList = Random.Range(0, fabricRustlingEffects.Count);
        }
        SoundManager.Instance.PlaySound(fabricRustlingEffects[fabricRustlingInList]);
        Debug.Log($"Playing sound effect number {fabricRustlingInList}");
        previousFabricRustlingInList = fabricRustlingInList;
    }

    public void PlayRandomWalkingQuiet()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        walkingQuietInList = Random.Range(0, walkingQuietEffects.Count); // roll new number
        if (walkingQuietInList == previousWalkingQuietInList) // if new number is same as previous number, reroll again
        {
            walkingQuietInList = Random.Range(0, walkingQuietEffects.Count);
        }
        SoundManager.Instance.PlaySound(walkingQuietEffects[walkingQuietInList]);
        Debug.Log($"Playing sound effect number {walkingQuietInList}");
        previousWalkingQuietInList = walkingQuietInList;
    }

    public void PlayRandomWalkingLoud()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        walkingLoudInList = Random.Range(0, walkingLoudEffects.Count); // roll new number
        if (walkingLoudInList == previousWalkingLoudInList) // if new number is same as previous number, reroll again
        {
            walkingLoudInList = Random.Range(0, walkingLoudEffects.Count);
        }
        SoundManager.Instance.PlaySound(walkingLoudEffects[walkingLoudInList]);
        Debug.Log($"Playing sound effect number {walkingLoudInList}");
        previousWalkingLoudInList = walkingLoudInList;
    }

    public void PlayRandomLightswitchOn()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        lightswitchOnInList = Random.Range(0, lightswitchOnEffects.Count); // roll new number
        if (lightswitchOnInList == previousLightswitchOnInList) // if new number is same as previous number, reroll again
        {
            lightswitchOnInList = Random.Range(0, lightswitchOnEffects.Count);
        }
        SoundManager.Instance.PlaySound(lightswitchOnEffects[lightswitchOnInList]);
        Debug.Log($"Playing sound effect number {lightswitchOnInList}");
        previousLightswitchOnInList = lightswitchOnInList;
    }

    public void PlayRandomLightswitchOff()
    {
        // reroll slightly reduces chances of same audio playing twice in a row
        lightswitchOffInList = Random.Range(0, lightswitchOffEffects.Count); // roll new number
        if (lightswitchOffInList == previousLightswitchOnInList) // if new number is same as previous number, reroll again
        {
            lightswitchOffInList = Random.Range(0, lightswitchOffEffects.Count);
        }
        SoundManager.Instance.PlaySound(lightswitchOffEffects[lightswitchOffInList]);
        Debug.Log($"Playing sound effect number {lightswitchOffInList}");
        previousLightswitchOnInList = lightswitchOffInList;
    }
}
    


