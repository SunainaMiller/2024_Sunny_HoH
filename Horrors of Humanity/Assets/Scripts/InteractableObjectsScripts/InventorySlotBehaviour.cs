using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotBehaviour : MonoBehaviour, IDropHandler
{
    void Start()
    {
        //gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            ItemDragDrop draggableItem = dropped.GetComponent<ItemDragDrop>();
            draggableItem.parentAfterDrag = transform;
        }

        //gameObject.transform.rotation = Quaternion.Euler(0, 10f, -10f);
    }
}
