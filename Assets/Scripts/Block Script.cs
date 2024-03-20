using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int blockhealth;
    public Collider2D mycollider;
    public Sprite Block3;
    public Sprite Block2;
    public Sprite Block1;
    public SpriteRenderer thisblock;
    public bool isdead;

    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blockhealth >= 3)
        {
            thisblock.sprite = Block3;
            thisblock.enabled = true;
            mycollider.enabled = true;
        }
        else if (blockhealth < 3 && blockhealth >= 2)
        {
            thisblock.sprite = Block2;
            thisblock.enabled = true;
            mycollider.enabled = true;
        }
        else if (blockhealth < 2 && blockhealth >= 1)
        {
            thisblock.sprite = Block1;
            thisblock.enabled = true;
            mycollider.enabled = true;
        }
        else if (blockhealth < 1 && blockhealth >= 0)
        {
            //Destroy(gameObject);
            thisblock.enabled = false;
            mycollider.enabled = false;
            if (isdead == false)
            {
                onDeath();
                isdead = true;
            }

        }
    }

    public void onDeath()
    {
        // Find the BallMovement1 script in the scene
        BallMovement1 ballMovement = FindObjectOfType<BallMovement1>();
        if (ballMovement != null && ballMovement.lastPaddleHit != null)
        {
            // Determine which player's paddle was the last to hit the ball
            bool isPlayerTwo = ballMovement.lastPaddleHit.isplayer2;

            // Find the ScoreManager script in the scene
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                // Add 5 points to the appropriate player's score
                scoreManager.AddScore(isPlayerTwo, 5);
                Debug.Log("added score");
            }
        }
        // Optionally activate a power-up
        /*PowerUpManager powerUpManager = FindObjectOfType<PowerUpManager>();
        if (powerUpManager != null)
        {
            powerUpManager.ActivateRandomPowerUp();
        }*/

        // Disable the block or handle its destruction
        isdead = true;
        gameObject.SetActive(false); // You could also deactivate the brick GameObject
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the other GameObject has a script component named "YourScriptName"
        BallMovement1 script = collision.gameObject.GetComponent<BallMovement1>();

        if (script != null)
        {
            Debug.Log("Found script on other GameObject!");
            blockhealth = blockhealth - 1;
        }
    }
}
