using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NotesDragDropBehaviour : ItemDragDrop, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject window;
    public bool onWindow = false;
    ButtonDisabling buttonDisabling;
    RectTransform rectTrans;
    public GameObject inventory;
    public GameObject bed;
    BedBehaviour bedBehaviour;

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }
    public override void UniqueOnBeginDrag()
    {
        rectTrans.localRotation = Quaternion.Euler(0, 0, 0);
        Debug.Log($"Unique on beginning drag from child");
    }
    public override void UniqueOnDrag()
    {
        Debug.Log($"Unique on drag from child");
    }
    public override void UniqueOnEndDrag()
    {
        SoundEffectSelection.Instance.PlayRandomPaperRustling();
        Debug.Log($"Unique on ending drag from child");
        if (transform.parent == window.transform) // if the parent is the window
        {
            Debug.Log($"Unique on ending drag from child, disable");
            onWindow = true;
            DrawingMechanic drawingMechanic = this.GetComponent<DrawingMechanic>();
            drawingMechanic.image.sprite = drawingMechanic.noteDrawings[0];
            // change sprite
            rectTrans.localRotation = Quaternion.Euler(0, 0, 0);
            buttonDisabling = this.GetComponent<ButtonDisabling>();
            buttonDisabling.DisableButton();
            // calling disable button
            bedBehaviour = bed.GetComponent<BedBehaviour>();
            bedBehaviour.BedWhenNoteDone();

            this.GetComponent<NotesDragDropBehaviour>().enabled = false;
            //this.enabled = false; // disable self
        }
        if (transform.parent == inventory.transform)
        {
            rectTrans.localRotation = Quaternion.Euler(0, 50f, 0);
        }
    }
}
