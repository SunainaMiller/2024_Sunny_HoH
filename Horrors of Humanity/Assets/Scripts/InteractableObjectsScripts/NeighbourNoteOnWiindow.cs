using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NeighbourNoteOnWiindow : MonoBehaviour
{
    RectTransform rectTrans;
    public GameObject inventory;
    public GameObject windowInventory;

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }
    void Start()
    {
        MoveToWindow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToWindow()
    {
        transform.SetParent(windowInventory.transform); // setting parent
        rectTrans.localRotation = Quaternion.Euler(0, 0, 0);
        Debug.Log($"Moving {gameObject}");
    }
    public void MoveToInventory()
    {
        transform.SetParent(inventory.transform); // setting parent
        rectTrans.localRotation = Quaternion.Euler(0, 50f, 0);
        transform.localScale = new Vector3(1.5f, -1.5f, 1.5f);
        Debug.Log($"Moving {gameObject}");
    }
}
