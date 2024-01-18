using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowBehaviour : MonoBehaviour, IClicked
{
    public GameObject windowPanel;
    public GameObject windowButton;
    public GameObject oppositeApartmentClose;
    public GameObject apartment;
    public GameObject bed;
    public GameObject pencil;
    PencilBehaviour pencilBehaviour;
    public GameObject paperStack;
    public GameObject curtain;
    public GameObject lightswitch;

    public GameObject smallNote;
    NotesDragDropBehaviour notesDrag;
    public GameObject note;

    private void Awake()
    {
        apartment.SetActive(true);
        windowPanel.SetActive(false);
        oppositeApartmentClose.transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
        windowButton.SetActive(true);
        bed.SetActive(true);
        pencil.SetActive(true);
        pencilBehaviour = pencil.GetComponent<PencilBehaviour>();
        paperStack.SetActive(true);
        curtain.SetActive(true);
        lightswitch.SetActive(true);

        notesDrag = note.GetComponent<NotesDragDropBehaviour>();
        smallNote.SetActive(false);
    }
    public void OnClick()
    {
        apartment.SetActive(false);
        windowPanel.SetActive(true);
        oppositeApartmentClose.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        windowButton.SetActive(false);
        bed.SetActive(false);
        paperStack.SetActive(false);
        curtain.SetActive(false);
        lightswitch.SetActive(false);

        pencil.SetActive(false);
        smallNote.SetActive(false);

        CursorBehaviour.instance.MouseExitHover();
        if(pencilBehaviour.pencilAquired) // if pencil has been aquired
        {
            pencil.SetActive(true);
        }
    }

    public void BackButton()
    {
        apartment.SetActive(true);
        oppositeApartmentClose.transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
        windowPanel.SetActive(false);
        windowButton.SetActive(true);
        bed.SetActive(true);
        paperStack.SetActive(true);
        curtain.SetActive(true);
        lightswitch.SetActive(true);

        pencil.SetActive(true);
        if (notesDrag.onWindow) // if note is on window, make small note appear
        {
            smallNote.SetActive(true);
            pencil.SetActive(false);
        }
    }
}
