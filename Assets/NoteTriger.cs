using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTrigger : MonoBehaviour
{
    public GameObject noteCanvas;  // Reference to the Canvas object containing the "Note" image

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PaperCode"))
        {
            // PaperCode object is touched by the player
            ShowNote();
        }
    }

    private void ShowNote()
    {
        if (noteCanvas != null)
        {
            // Set the "Note" image in the Canvas to be active
            Image noteImage = noteCanvas.GetComponentInChildren<Image>();
            if (noteImage != null)
            {
                noteImage.enabled = true;
            }
            else
            {
                Debug.LogError("Note image not found in the Canvas.");
            }
        }
        else
        {
            Debug.LogError("Note Canvas reference is missing.");
        }
    }
}
