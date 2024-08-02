using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] float holdDuration = 2f; // Adjust the required hold duration as needed
    private bool isCollecting = false;
    private GameObject player;

    private void Update()
    {
        if (!isCollecting && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(CollectCoroutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    IEnumerator CollectCoroutine()
    {
        if (player != null)
        {
            isCollecting = true;

            float holdTimer = 0f;

            while (Input.GetKey(KeyCode.E) && holdTimer < holdDuration)
            {
                holdTimer += Time.deltaTime;
                yield return null;
            }

            if (holdTimer >= holdDuration)
            {
                TryCollect();
            }

            isCollecting = false;
        }
    }

    private void TryCollect()
    {
        // Check if the player is still in the vicinity (optional)
        if (player != null)
        {
            // Implement your collection logic here
            // This will be triggered when the player holds down the "E" key for the required duration and is near the correct object
            Collected();
        }
    }

    protected virtual void Collected()
    {
        // Implement your collection logic here
        // This will be triggered when the player holds down the "E" key for the required duration and is near the correct object
        Destroy(gameObject); // For example, destroy the collected object
    }
}