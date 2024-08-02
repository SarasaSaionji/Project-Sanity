using UnityEngine;
using UnityEngine.UI;

public class PaperCode : MonoBehaviour
{
    public Canvas noteCanvas;  // Reference to the Canvas containing the "Note" image

    private void Start()
    {
        // Make sure the note is initially hidden
        HideNote();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CollegeStudent"))
        {
            // CollegeStudent object is touching the PaperCode object
            ShowNote();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CollegeStudent"))
        {
            // CollegeStudent object is no longer touching the PaperCode object
            HideNote();
        }
    }

    private void ShowNote()
    {
        if (noteCanvas != null)
        {
            noteCanvas.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Note Canvas reference is missing. Assign the 'Note' Canvas in the Inspector.");
        }
    }

    private void HideNote()
    {
        if (noteCanvas != null)
        {
            noteCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Note Canvas reference is missing. Assign the 'Note' Canvas in the Inspector.");
        }
    }
}
