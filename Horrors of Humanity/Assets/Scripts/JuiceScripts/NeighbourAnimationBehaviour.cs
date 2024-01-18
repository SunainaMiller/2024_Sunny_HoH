using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourAnimationBehaviour : MonoBehaviour
{
    float randomWaitTime = 1f;
    Animator neighbourAnimator;
    bool animPlayed;
    bool animCalled;

    private void Start()
    {
        neighbourAnimator = gameObject.GetComponent<Animator>();
        animPlayed = false;
        animCalled = false;
    }
    private void Update()
    {
        if(animPlayed && !animCalled)
        {
            animPlayed = false;
            neighbourAnimator.enabled = false;
        }
        else if(!animPlayed && !animCalled)
        {
            neighbourAnimator.enabled = true;
            AnimationWaitCall();
            animCalled = true;
            Debug.Log($"Calling wait for neighbour anim");
        }
    }

    void AnimationWaitCall()
    {
        //randomWaitTime = Random.Range(1f, 2f);
        
        StartCoroutine(WaitCoroutine());
        Debug.Log($"Calling for coroutine neighbour anim");
    }
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(randomWaitTime);
        neighbourAnimator.Play("NeighbourIdle");
        animPlayed = true;
        animCalled = false;
        Debug.Log($"Neighbour animation played");
    }
}
