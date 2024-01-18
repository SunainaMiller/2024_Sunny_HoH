using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DrawingMechanic : InteractableObjectsParent, IClicked, IEndDragHandler
{
    int clicks;
    [HideInInspector] public bool drawingIsDone;

    [HideInInspector] public Image image;
    RectTransform rectTrans;
    public List<Sprite> noteDrawings;
    NotesDragDropBehaviour dragDrop;

    public GameObject canvasParent;
    public GameObject inventory;

    public GameObject pencil;
    PencilBehaviour pencilBehaviour;

    float startingAnchors = 0.5f;
    void Awake()
    {
        clicks = 0;
        image = GetComponent<Image>();
        rectTrans = GetComponent<RectTransform>();
        dragDrop = GetComponent<NotesDragDropBehaviour>();
        pencilBehaviour = pencil.GetComponent<PencilBehaviour>();
        image.sprite = noteDrawings[clicks];

        dragDrop.enabled = false;
        drawingIsDone = false;
        MoveToInventory();
        pencil.SetActive(true);
    }

    void StartingPosition()
    {
        rectTrans.pivot = new Vector2(startingAnchors, startingAnchors);
        rectTrans.anchorMin = new Vector2(startingAnchors, startingAnchors);
        rectTrans.anchorMax = new Vector2(startingAnchors, startingAnchors);

        rectTrans.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = new Vector3(0, 0, 0);
    }
    public override void OnClick()
    {   
        if(pencilBehaviour.pencilAquired)
        {
            transform.SetParent(canvasParent.transform);
            StartingPosition();
            pencil.SetActive(false);
            CursorBehaviour.instance.isPencilTime = true;

            if (clicks >= 4) // if the note has been click 3 or more times // if note has been clicked equal or more of the list noteDrawings.Count
            {
                if(!drawingIsDone) // and it has not yet been confirmed
                {
                    drawingIsDone = true; // confirm that the drawing is done
                    dragDrop.enabled = true;
                    MoveToInventory();
                    pencilBehaviour.pencilAquired = false;
                    CursorBehaviour.instance.isPencilTime = false;
                    return;
                }
            }
            else
            {
                SoundEffectSelection.Instance.PlayRandomDrawing();
                clicks++;
                image.sprite = noteDrawings[clicks];
                //changing sprite according to how many clicks have been made
            }
        }
        Debug.Log($"{gameObject} has been clicked {clicks} times");
    }
    void MoveToInventory()
    {
        transform.SetParent(inventory.transform); // setting parent
        rectTrans.localRotation = Quaternion.Euler(0, 50f, 0);
        //
        // animate
        Debug.Log($"Moving {gameObject}");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log($"Drawing Mechanics end drag");
        if (dragDrop.onWindow) // if the parent is the window
        {
            image.sprite = noteDrawings[0]; // if note is on the window, reset to plain sprite
            Debug.Log($"Drawing Mechanics end drag sprite change");
        }
        
    }
}
