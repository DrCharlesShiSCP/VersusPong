using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private BallMovement1 ball; // Reference to your Ball script
    private float originalBallSpeed;
    private bool isBallSpeedReduced = false;
    [SerializeField] private PalletMovement paddle; // Reference to your Paddle script
    private float originalPaddleSpeed;
    private bool isPaddleSpeedIncreased = false;
    [SerializeField] private GameObject ballPrefab; // Reference to your Ball prefab
    private List<GameObject> extraBalls = new List<GameObject>();

    public enum State
    {
        Standard,
        BallSpeedDown,
        PalletSpeedUp,
        MultiBall,
        BlockHP
    }

    private State currentState;

    private void Start()
    {
        TransitionToState(State.Standard);
    }

    private void Update()
    {
        // Example: transition from Idle to Moving after 2 seconds
        /*if (currentState == State.Standard && Time.time > 2f)
        {
            TransitionToState(State.Moving);
        }*/
    }

    private void TransitionToState(State newState)
    {
        OnExitState(currentState);
        currentState = newState;
        OnEnterState(currentState);
    }
    public void ActivateRandomPowerUp()
    {
        if (Random.Range(0f, 1f) <= 0.15f) // 15% chance
        {
            // Get a random value for the State enum, excluding the 'Standard' state
            State randomState = (State)Random.Range(1, System.Enum.GetValues(typeof(State)).Length);
            TransitionToState(randomState);
        }
    }

    private void OnEnterState(State state)
    {
        switch (state)
        {
            case State.BallSpeedDown:
                // Logic to slow down the ball
                break;
            case State.PalletSpeedUp:
                // Logic to speed up the paddle
                break;
            case State.MultiBall:
                // Logic to create additional balls
                break;
            case State.BlockHP:
                // Logic to increase block hit points
                break;
            default:
                break;
        }
    }


    private void OnExitState(State state)
    {
        Debug.Log("Exiting state: " + state);
        // Perform any actions necessary upon exiting this state
    }

    public void Standard()
    {

    }

    public void BallSpeedDown()
    {
        if (!isBallSpeedReduced)
        {
            originalBallSpeed = ball.initialSpeed; //ball script has a 'speed' variable
            ball.initialSpeed *= 0.5f; // Halve the ball's speed
            isBallSpeedReduced = true;
            StartCoroutine(ResetBallSpeedAfterDelay(10f));
        }
    }

    private IEnumerator ResetBallSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ball.initialSpeed = originalBallSpeed;
        isBallSpeedReduced = false;
    }
    public void PalletSpeedUp()
    {
        if (!isPaddleSpeedIncreased)
        {
            originalPaddleSpeed = paddle.moveSpeed; // Assuming your paddle script has a 'speed' variable
            paddle.moveSpeed *= 1.5f; // Increase the paddle's speed by 50%
            isPaddleSpeedIncreased = true;
            StartCoroutine(ResetPaddleSpeedAfterDelay(10f));
        }
    }

    private IEnumerator ResetPaddleSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        paddle.moveSpeed = originalPaddleSpeed;
        isPaddleSpeedIncreased = false;
    }

    public void MultiBall()
    {
        for (int i = 0; i < 2; i++) // Create two additional balls
        {
            GameObject newBall = Instantiate(ballPrefab, ball.transform.position, Quaternion.identity);
            // Assuming the ball prefab has a script attached that automatically sets its velocity
            extraBalls.Add(newBall);
        }

        StartCoroutine(DestroyExtraBallsAfterDelay(10f));
    }

    private IEnumerator DestroyExtraBallsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        foreach (GameObject extraBall in extraBalls)
        {
            if (extraBall != null)
            {
                Destroy(extraBall);
            }
        }
        extraBalls.Clear();
    }

    public void BlockHP()
    {

    }
}
