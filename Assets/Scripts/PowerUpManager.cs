using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class PowerUpManager : MonoBehaviour
{
    public BallMovement1 ballMovementScript;
    private float originalBallSpeed;
    private bool isBallSpeedReduced = false;

    public string BlockTag1;
    public string BlockTag2;


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
        GameObject[] Player1Blocks = GameObject.FindGameObjectsWithTag(BlockTag1);
        GameObject[] Player2Blocks = GameObject.FindGameObjectsWithTag(BlockTag2);
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
            originalBallSpeed = ballMovementScript.initialSpeed; //ball script has a 'speed' variable
            ballMovementScript.initialSpeed *= 0.5f; // Halve the ball's speed
            isBallSpeedReduced = true;
            StartCoroutine(ResetBallSpeedAfterDelay(10f));
        }
    }

    private IEnumerator ResetBallSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ballMovementScript.initialSpeed = originalBallSpeed;
        isBallSpeedReduced = false;
    }
    public void PalletSpeedUp()
    {
        if (ballMovementScript.lastPaddleHit != null)
        {
            // Apply the speed up power-up directly to the last paddle hit
            StartCoroutine(PaddleSpeedUpRoutine(ballMovementScript.lastPaddleHit));
        }
    }

    private IEnumerator PaddleSpeedUpRoutine(PalletMovement paddleScript)
    {
        float originalSpeed = paddleScript.moveSpeed;
        paddleScript.moveSpeed *= 1.5f; //increase speed by 50%
        yield return new WaitForSeconds(10); // Wait for 10 seconds
        paddleScript.moveSpeed = originalSpeed; // Reset to original speed
    }

    public void MultiBall()
    {
        for (int i = 0; i < 2; i++) // Create two additional balls
        {
            GameObject newBall = Instantiate(ballPrefab, ballMovementScript.transform.position, Quaternion.identity);
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
        
        if (ballMovementScript.hitP1Last == true)
        {
            GameObject[] Player1Blocks = GameObject.FindGameObjectsWithTag(BlockTag1);
            foreach (GameObject taggedObject in Player1Blocks)
            {
                // Get all components attached to the tagged object
                Component[] block1 = taggedObject.GetComponents<BlockScript>();

                foreach (Component component in block1)
                {
                    // Check if the component has any public integer fields
                    foreach (var blockhealth in component.GetType().GetFields())
                    {
                        if (blockhealth.FieldType == typeof(int))
                        {
                            // Add 1 to the integer field
                            blockhealth.SetValue(component, ((int)blockhealth.GetValue(component)) + 1);
                        }
                    }
                }
            }
        }
        if (ballMovementScript.hitP1Last == false)
        {
            GameObject[] Player2Blocks = GameObject.FindGameObjectsWithTag(BlockTag2);
            foreach (GameObject taggedObject in Player2Blocks)
            {
                // Get all components attached to the tagged object
                Component[] block1 = taggedObject.GetComponents<BlockScript>();

                foreach (Component component in block1)
                {
                    // Check if the component has any public integer fields
                    foreach (var blockhealth in component.GetType().GetFields())
                    {
                        if (blockhealth.FieldType == typeof(int))
                        {
                            // Add 1 to the integer field
                            blockhealth.SetValue(component, ((int)blockhealth.GetValue(component)) + 1);
                        }
                    }
                }
            }
        }

    }
}
