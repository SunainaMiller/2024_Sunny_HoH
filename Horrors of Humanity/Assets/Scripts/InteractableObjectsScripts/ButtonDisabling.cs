using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonDisabling : MonoBehaviour
{
    Button button;
    UICursorHoverTrigger cursorHover;
    public void Start()
    {
        button = this.GetComponent<Button>(); // getting Button component script is attached to
        button.enabled = true;
        cursorHover = this.GetComponent<UICursorHoverTrigger>();
        cursorHover.enabled = true;
        //button.interactable = true;
    }

    public void DisableButton()
    {
        button.enabled = false;
        cursorHover.enabled = false;
        //button.interactable = false;
    }
}
