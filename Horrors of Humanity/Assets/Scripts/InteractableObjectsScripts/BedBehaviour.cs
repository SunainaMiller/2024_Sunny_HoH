using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedBehaviour : InteractableObjectsParent, IClicked
{
    public GameObject bedConfirmationPanel;
    public GameObject pauseMenuCanvas;
    PauseMenu pauseMenuScript;
    NotesDragDropBehaviour notesDrag;
    public GameObject note;
    ButtonDisabling buttonDisabling;

    public GameObject apartment;
    public GameObject window;
    public GameObject paperstack;

    void Start()
    {
        bedConfirmationPanel.SetActive(false);
        pauseMenuScript = pauseMenuCanvas.GetComponent<PauseMenu>();
        notesDrag = note.GetComponent<NotesDragDropBehaviour>();
        buttonDisabling = GetComponent<ButtonDisabling>();
        buttonDisabling.DisableButton(); // disable bed button bc player has not yet finished note
    }
    public override void OnClick()
    {
        if(notesDrag.onWindow) // if note is on window aka task complete, allow player the choice to sleep
        {
            bedConfirmationPanel.SetActive(true);
            Debug.Log($"{gameObject} has been clicked");

            apartment.SetActive(false);
            window.SetActive(false);
            paperstack.SetActive(false);
        }
    }
    public void ReturnToRoom()
    {
        apartment.SetActive(true);
        window.SetActive(true);
        paperstack.SetActive(true);
    }
    public void BedWhenNoteDone()
    {
        buttonDisabling.Start(); // enable button
    }
}