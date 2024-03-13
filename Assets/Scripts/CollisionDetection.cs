using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CollisionDetection : MonoBehaviour
{
    private int player1life = 3; 
    private int player2life = 3; 
    public TextMeshProUGUI player1health;
    public TextMeshProUGUI player2health;
    public GameObject gameover1;
    public GameObject gameover2;
    public GameObject ballGameObject; 

    private void Start()
    {
        gameover1.SetActive(false);
        gameover2.SetActive(false);
        UpdateHealth1Display();
        UpdateHealth2Display();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is player backwall
        if (collision.gameObject.CompareTag("playerwall1"))
        {
            player1life -= 1;
            UpdateHealth1Display();
            if (player1life <= 0)
            {
                Kill1();
            }
            resetBall();
        }
        else if (collision.gameObject.CompareTag("playerwall2"))
        {
            player2life -= 1;
            UpdateHealth2Display();
            if (player2life <= 0)
            {
                Kill2();
            }
            resetBall();
        }
    }

    void Kill1()
    {
        gameover1.SetActive(true);
        Debug.Log("Player1 has been killed!");
    }

    void Kill2()
    {
        gameover2.SetActive(true);
        Debug.Log("Player2 has been killed!");
    }

    void UpdateHealth1Display()
    {
        player1health.text = "Health: " + player1life;
    }

    void UpdateHealth2Display()
    {
        player2health.text = "Health: " + player2life;
    }
    void resetBall()
    {
        // Check if the ball GameObject reference is set
        if (ballGameObject != null)
        {
            BallMovement1 ballMovementScript = ballGameObject.GetComponent<BallMovement1>();
            if (ballMovementScript != null)
            {
                // Modify the upSpeed and initialSpeed
                ballMovementScript.upSpeed = 0.1f; 
                ballMovementScript.initialSpeed = 6.0f; 
            }
        }
        ballGameObject.transform.position = Vector2.zero;
    }
}
