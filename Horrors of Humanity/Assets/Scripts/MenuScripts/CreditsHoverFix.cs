using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHoverFix : MonoBehaviour
{
    public GameObject cursor;
    CursorBehaviour cursorBehaviour;
    private void Awake()
    {
        cursorBehaviour = cursor.GetComponent<CursorBehaviour>();
        cursorBehaviour.MouseExitHover();
    }
}
