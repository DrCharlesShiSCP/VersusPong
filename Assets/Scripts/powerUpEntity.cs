using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpEntity : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to your ScoreManager script
    public PowerUpManager powerUpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PalletMovement paddle = collision.GetComponent<PalletMovement>();
        if (paddle != null)
        {
            // Determine which player collided and grant them a power-up
            bool isPlayerTwo = paddle.isplayer2;
            GrantPowerUp(isPlayerTwo);
        }
    }

    void GrantPowerUp(bool isPlayerTwo)
    {
        // Assuming we're simply adding points as a power-up for demonstration
        if (scoreManager != null)
        {
            scoreManager.AddScore(isPlayerTwo, 10); // Add 5 points as a power-up

            // Optionally, deactivate or destroy the power-up GameObject to prevent re-use
            gameObject.SetActive(false); // Deactivate
            // Destroy(gameObject); // Or destroy
        }
        else
        {
            Debug.LogError("ScoreManager reference not set in PowerUpTrigger.");
        }
        powerUpManager.ActivateRandomPowerUp();
    }
}
