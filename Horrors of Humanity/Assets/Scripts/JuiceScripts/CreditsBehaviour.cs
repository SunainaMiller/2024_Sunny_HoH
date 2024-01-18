using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsBehaviour : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // confining cursor to game screen
        Cursor.visible = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) // if enter is pressed, go to main menu
        {
            AfterCredits();
        }
    }
    public void AfterCredits()
    {
        SceneManager.LoadScene(1); // after credits load main menu
    }
}
