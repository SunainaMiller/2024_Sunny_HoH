using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PencilBehaviour : ItemDragDrop, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject inventory;
    RectTransform rectTrans;
    ButtonDisabling buttonDisabling;
    public bool pencilAquired;
    public Sprite smallPencil, bigPencil;

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        pencilAquired = false;
        image.sprite = smallPencil;
        //rectTrans.localRotation = Quaternion.Euler(0, 0, 0);
        //rectTrans.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
    public void MoveToInventory()
    {
        transform.SetParent(inventory.transform); // setting parent
        pencilAquired = true;
        image.sprite = bigPencil;
        rectTrans.localRotation = Quaternion.Euler(0, 0, -25f);
        rectTrans.localScale = new Vector3(2f, 2f, 2f);

        buttonDisabling = this.GetComponent<ButtonDisabling>();
        buttonDisabling.DisableButton();
        // calling disable button
        //
        // animate
        Debug.Log($"Moving {gameObject}");
    }
    /*public override void UniqueOnEndDrag()
    {
        Debug.Log($"Unique on ending drag from child");
        if (transform.parent == inventory.transform) // if the pencil is in the inventory slot
        {
            
            // needs to be able to be dragged onto the note
            // or click note
            // to enable drawing

            Debug.Log($"Unique on ending drag from child, disable");
            


            this.GetComponent<PencilBehaviour>().enabled = false;
            //this.enabled = false; // disable self
        }
    }*/
}
