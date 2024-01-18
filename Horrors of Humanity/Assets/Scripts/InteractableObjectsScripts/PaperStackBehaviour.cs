using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStackBehaviour : InteractableObjectsParent, IClicked
{
    public GameObject note;
    DrawingMechanic noteBehaviour;

    void Start()
    {
        note.SetActive(false);
        noteBehaviour = note.GetComponent<DrawingMechanic>();
    }
    public override void OnClick()
    {
        note.SetActive(true);
        Debug.Log($"{gameObject} has been clicked");
    }
}
