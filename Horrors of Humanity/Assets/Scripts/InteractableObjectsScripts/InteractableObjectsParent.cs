using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectsParent : MonoBehaviour, IClicked
{
    public GameObject cursor;
    public void OnMouseEnter()
    {
        CursorBehaviour cursorBehaviour = cursor.GetComponent<CursorBehaviour>();
        cursorBehaviour.MouseEnterHover();
        Debug.Log($"{gameObject} entered to hover");
    }
    public void OnMouseOver()
    {
        // give outline/hightlight
        // change cursor
        CursorBehaviour cursorBehaviour = cursor.GetComponent<CursorBehaviour>();
        cursorBehaviour.isHovering = true;
    }

    public void OnMouseExit()
    {
        // get rid of outline/hightlight
        // change cursor
        CursorBehaviour cursorBehaviour = cursor.GetComponent<CursorBehaviour>();
        cursorBehaviour.MouseExitHover();
    }

    public virtual void OnClick()
    {
        Debug.Log($"{gameObject} has been clicked");
    }
}
