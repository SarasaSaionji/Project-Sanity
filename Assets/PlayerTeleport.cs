using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool isTeleporting = false;
    private float teleportHoldTime = 1f;
    private float currentHoldTime = 0f;

    void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Start the teleportation coroutine
            StartCoroutine(TeleportCoroutine());
        }

        // Check if the "E" key is released
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Stop the teleportation coroutine and reset the timer
            StopCoroutine(TeleportCoroutine());
            currentHoldTime = 0f;
            isTeleporting = false;
        }
    }

    IEnumerator TeleportCoroutine()
    {
        isTeleporting = true;

        while (isTeleporting)
        {
            // Increment the hold time while the "E" key is held down
            currentHoldTime += Time.deltaTime;

            // Check if the hold time has reached the desired duration
            if (currentHoldTime >= teleportHoldTime)
            {
                // Teleport if the hold time is sufficient
                if (currentTeleporter != null)
                {
                    transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                }

                // Reset the timer and flag
                currentHoldTime = 0f;
                isTeleporting = false;
            }

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            // Check if the exiting teleporter is the current teleporter
            if (collision.gameObject == currentTeleporter)
            {
                // Set currentTeleporter to null when the current teleporter exits
                currentTeleporter = null;
            }
        }
    }
}