using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement1 : MonoBehaviour
{
    public float initialSpeed = 6.0f; // Set a fixed initial speed
    private Rigidbody2D rb;
    private bool gameStarted = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Add initial force to the ball after a delay
        Invoke("LaunchBall", 1f);
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

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1; // Left or right
        float y = Random.Range(0.5f, 1f); // Randomize the initial y direction
        Vector2 direction = new Vector2(x, y).normalized;
        rb.AddForce(direction * initialSpeed, ForceMode2D.Impulse);
        gameStarted = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Add a little randomness to the bounce
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        rb.velocity += tweak;

        // Speed up the ball every time it hits something
        Speedup();

        // Here you can add code to handle collision with bricks, like destroying the brick
    }

    void Speedup()
    {
        // Directly increase the speed without relying on Time.deltaTime since this method is not called every frame
        initialSpeed += 0.1f; // Adjust the value to control speed increment rate
    }
}
