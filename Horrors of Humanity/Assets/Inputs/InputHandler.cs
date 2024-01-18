using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance { get; set; }
    public Camera mainCam;
    //PlayerInput hotKeys;

    // for no input detection
    Scene currentScene;
    int buildIndex;
    int gameplaySceneNumber;
    public float waitUntil;
    float countingNoInput = 0;
    bool gameplayLoadedDone;

    GameObject videoPlayer;

    private void Start()
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
        //hotKeys.Gameplay.Footage.started += _ => LoadGameplayFootageScene(); // when we've started clicking, call StartedClick()
        //hotKeys.Gameplay.Footage.performed += _ => EndedClick(); // when we're done clicking, call EndedClick()
        
        waitUntil = 300f;
        videoPlayer = GameObject.Find("Video Player");
        gameplayLoadedDone = false;
    }
    private void Awake()
    {
        mainCam = Camera.main;
        //hotKeys = new PlayerInput();
    }

    public void OnClick(InputAction.CallbackContext context) // on click
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);
    }

    void Update()
    {
        countingNoInput += Time.deltaTime;

        bool isMouseMove = Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0;

        if (Input.anyKey || isMouseMove) // if there has been input
        {
            if (videoPlayer.activeInHierarchy) // and if we are in the gameplay scene, return to previous scene
            {
                countingNoInput = 0;
                SceneManager.LoadScene(1);
                Debug.Log($"In Gameplay Scene");
            }
            else
            {
                countingNoInput = 0; // else just reset the timer
            }
        }

        if (countingNoInput >= waitUntil) // if timer is up, load gameplay footage
        {
            countingNoInput = 0;
            LoadGameplayFootageScene();
        }
    }

    void LoadGameplayFootageScene()
    {
        SceneManager.LoadScene(6);
        Debug.Log($"Loading afk gameplay footage {gameplayLoadedDone}");
        
    }
}
