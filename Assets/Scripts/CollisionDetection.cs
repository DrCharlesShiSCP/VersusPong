using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CollisionDetection : MonoBehaviour
{
    //private int player1life = 2; 
    //private int player2life = 2; 
    public TextMeshProUGUI player1health;
    public TextMeshProUGUI player2health;
    public GameObject gameover1;
    public GameObject gameover2;
    public GameObject ballGameObject;

    public GameObject GameAudio;
    public GameObject EndAudio;

    public PalletMovement lastPaddleHit;

    private void Start()
    {
        Time.timeScale = 1f;
        gameover1.SetActive(false);
        gameover2.SetActive(false);
        //UpdateHealth1Display();
        //UpdateHealth2Display();
    }

    public void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerwall1"))
        {
            ScoreManager script = FindObjectOfType<ScoreManager>();
            script.player2Score = script.player2Score + 15;
            script.player2ScoreText.text = "Score: " + script.player2Score;
            resetBall();
        }
        else if (collision.gameObject.CompareTag("playerwall2"))
        {
            ScoreManager script = FindObjectOfType<ScoreManager>();
            script.player1Score = script.player1Score + 15;
            script.player1ScoreText.text = "Score: " + script.player1Score;
            resetBall();
        }
    }

        void resetBall()
        {
            // Check if the ball GameObject reference is set
            if (ballGameObject != null)
            {
                ballGameObject.GetComponent<TrailRenderer>().enabled = false;
                BallMovement1 ballMovementScript = ballGameObject.GetComponent<BallMovement1>();
                if (ballMovementScript != null)
                {
                    // Modify the upSpeed and initialSpeed
                    ballMovementScript.upSpeed = 0.1f;
                    ballMovementScript.initialSpeed = 6.0f;
                }
            }
            lastPaddleHit = null;
            ballGameObject.transform.position = Vector2.zero;
            ballGameObject.GetComponent<TrailRenderer>().enabled = true;
        }
}
