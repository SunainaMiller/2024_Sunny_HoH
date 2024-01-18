using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public Animator menuUIAnimator;

    public PauseMenu menuScript;
    public GameObject weatherControlsPanel;
    public GameObject movementControlsPanel;

    bool timerIsRunning = true;
    float timeRemaining = 7f;

    bool movementTutorialDone = false;
    bool weatherTutorialDone = false;
    public bool tutorialDone = false;

    private void Awake()
    {
        weatherControlsPanel.SetActive(false);
        movementControlsPanel.SetActive(false);
    }

    private void Update()
    {
        Timer();

        if (!movementTutorialDone && Input.GetKeyDown(KeyCode.A) || !movementTutorialDone && Input.GetKeyDown(KeyCode.D)) //if movement tutorial is not done & player does input, don't show tutorial
        {
            HideMovementutorial();
        }
        if(!weatherTutorialDone && Input.GetMouseButtonDown(0)) //if press LMB
        {
            HideWeatherTutorial();
        }

        if(weatherTutorialDone && movementTutorialDone)
        {
            tutorialDone = true;
        }
    }

    void Timer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time for tutorial");
                timeRemaining = 0;
                timerIsRunning = false;

                //make tutorial appear
                if(movementTutorialDone == false) // reset timer
                {
                    MovementTutorial();
                }
                else
                {
                    WeatherTutorial();
                }
            }
        }
    }

    void MovementTutorial()
    {
        movementControlsPanel.SetActive(true);
        menuUIAnimator.Play("MovementTutorialAppear");
        Debug.Log("Showing tutorial bc inut has not been given");
    }

    void HideMovementutorial()
    {
        movementControlsPanel.SetActive(false);
        menuUIAnimator.Play("MovementTutorialDisappear");
        movementTutorialDone = true;
        Debug.Log("Hiding tutorial bc inut has been given");

        //reset timer
        timeRemaining = 5f;
        timerIsRunning = true;
    }

    void WeatherTutorial()
    {
        weatherControlsPanel.SetActive(true);
        menuUIAnimator.Play("WeatherTutorialIdle");
        Debug.Log("Showing weather tutorial bc inut has not been given");
    }

    void HideWeatherTutorial()
    {
        weatherControlsPanel.SetActive(false);
        Debug.Log("Hiding weather tutorial bc inut has been given");
        weatherTutorialDone = true;
        menuUIAnimator.Play("WeatherTutorialDisappear");
        //reset timer
        timeRemaining = 5f;
        timerIsRunning = true;
    }
}
