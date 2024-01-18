using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICursorHoverTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cursor;
    CursorBehaviour cursorBehaviour;
    [SerializeField] static float highlightedScale = 1.04f;
    Vector3 startScale;
    void Awake()
    {
        cursorBehaviour = cursor.GetComponent<CursorBehaviour>();
        cursorBehaviour.isHovering = false;
        // gameObject.transform.localScale = new Vector3(normalScale, normalScale, normalScale); // setting (button) scale to 1
        startScale = gameObject.transform.localScale; // saving initial size to startScale Vector
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cursorBehaviour.MouseEnterHover();
        //gameObject.transform.localScale = new Vector3(highlightedScale, highlightedScale, highlightedScale); //
        gameObject.transform.localScale *= highlightedScale;
        Debug.Log($"Mouse entered {eventData.pointerEnter}");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cursorBehaviour.MouseExitHover();
        gameObject.transform.localScale = startScale; //
        Debug.Log($"Mouse exited button");
    }
}
