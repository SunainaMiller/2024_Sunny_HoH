using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    public void OnBeginDrag(PointerEventData eventData)
    {   // changing parent to stay on top
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); // places object right at the bottom, making it on top of everything
        image.raycastTarget = false;
        UniqueOnBeginDrag();
        Debug.Log($"Beginning drag");
    }

    public void OnDrag(PointerEventData eventData)
    {   // dragged item sticks to mouse
        transform.position = Input.mousePosition;
        UniqueOnDrag();
        Debug.Log($"Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        UniqueOnEndDrag();
        Debug.Log($"Ending drag");
    }
    public virtual void UniqueOnBeginDrag()
    {
        Debug.Log($"Unique on beginning drag");
    }
    public virtual void UniqueOnDrag()
    {
        Debug.Log($"Unique on drag");
    }
    public virtual void UniqueOnEndDrag()
    {
        Debug.Log($"Unique on ending drag");
    }
}
