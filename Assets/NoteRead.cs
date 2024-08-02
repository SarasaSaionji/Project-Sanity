using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteRead : MonoBehaviour
{
    public GameObject NotePopup;
    public GameObject SatanNote; // Reference to the Canvas UI GameObject
    private bool isNoteRead = false;
    private bool wasInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NoteTask"))
        {
            wasInTrigger = true;

            if (!isNoteRead)
            {
                ToggleNoteReadState();
                UpdateSatanNoteState();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (wasInTrigger && collision.CompareTag("NoteTask"))
        {
            wasInTrigger = false;

            if (isNoteRead)
            {
                ToggleNoteReadState();
                UpdateSatanNoteState();
            }
        }
    }

    void ToggleNoteReadState()
    {
        isNoteRead = !isNoteRead;
        Debug.Log("Note Read State: " + isNoteRead);
    }

    void UpdateSatanNoteState()
    {
        if (SatanNote != null)
        {
            SatanNote.SetActive(isNoteRead);
            Debug.Log("SatanNote Active: " + isNoteRead);
        }
    }
}
