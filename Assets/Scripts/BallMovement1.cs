using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement1 : MonoBehaviour
{
    public float initialSpeed = 6.0f; // Set a fixed initial speed
    private Rigidbody2D rb;
    private bool gameStarted = false;
    public float upSpeed;
    public float maxSpeed = 10.0f;
    public CollosionEffects Particles;
    public GameObject ParticleSystem;
    
    public PalletMovement lastPaddleHit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Add initial force to the ball after a delay
        Invoke("LaunchBall", 1f);
        StartSpeedupRoutine();
    }
    void StartSpeedupRoutine()
    {
        StartCoroutine(CallSpeedupEvery5Seconds());
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
            PalletMovement paddleHit = collision.gameObject.GetComponent<PalletMovement>();
            if (paddleHit != null)
            {
            // Calculate difference in positions
                float positionDifference = transform.position.x - collision.transform.position.x;

                // Normalize the difference in position
                float normalizedDifference = positionDifference / (collision.collider.bounds.size.x / 2);
                lastPaddleHit = paddleHit;
                // Calculate new vector
                float angle = normalizedDifference * 45.0f; // Adjust the angle as needed
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

                // Apply the new direction with the same speed
                rb.velocity = direction * rb.velocity.magnitude;
            }
            else
            {
                // Add a little randomness to the bounce off other surfaces
                Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
                rb.velocity += tweak;
            }

            // Optionally, speed up the ball
            Speedup();
            Particles.PlayCollisionEffect();
            ParticleSystem.SetActive(true);
    }
    IEnumerator CallSpeedupEvery5Seconds()
    {
        while (initialSpeed < maxSpeed)
        {
            Speedup();
            yield return new WaitForSeconds(5f); // Wait for 5 seconds before calling Speedup again
        }
    }
    void Speedup()
    {
        if (initialSpeed < maxSpeed)
        {
            initialSpeed += upSpeed; // Increase speed by a fixed amount. Adjust this value as needed.
            initialSpeed = Mathf.Min(initialSpeed, maxSpeed); // Ensures speed does not exceed maxSpeed
        }
    }
}
