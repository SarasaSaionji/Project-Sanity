using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    [SerializeField] int coinValue = 1;
    [SerializeField] AudioClip collectedSound;  // Add an AudioClip field for the collected sound

    protected override void Collected()
    {
        PlayCollectedSound();  // Play the sound
        DestroyObject();       // Destroy the object
    }

    private void PlayCollectedSound()
    {
        // Check if an AudioClip is assigned
        if (collectedSound != null)
        {
            // Play the sound at the object's position
            AudioSource.PlayClipAtPoint(collectedSound, transform.position);
        }
    }

    private void DestroyObject()
    {
        GameManager.MyInstance.AddCoins(coinValue);
        Destroy(this.gameObject);
    }
}