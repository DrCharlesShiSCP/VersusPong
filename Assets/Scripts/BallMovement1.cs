using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement1 : MonoBehaviour
{
    public float initialSpeed = 600f;
    private Rigidbody2D rb;
    private bool gameStarted = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Add initial force to the ball
        AddInitialForce();
    }

    void Update()
    {
        // Check if the game has started and the ball is moving too slow
        if (gameStarted && rb.velocity.magnitude < initialSpeed * 0.5f)
        {
            // Normalize velocity and set to initial speed
            rb.velocity = rb.velocity.normalized * initialSpeed;
        }
    }

    void AddInitialForce()
    {
        // Wait for 1 second before starting the game
        Invoke("LaunchBall", 1f);
    }

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1; // Left or right
        float y = Random.Range(0.5f, 1f); // Randomize the initial y direction
        rb.AddForce(new Vector2(x, y).normalized * initialSpeed);
        gameStarted = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Add a little randomness to the bounce
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        rb.velocity += tweak;

        // Here you can add code to handle collision with bricks, like destroying the brick
    }
}
