using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
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

    private void OnEnterState(State state)
    {
        Debug.Log("Entering state: " + state);
        // Perform any actions necessary upon entering this state
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

    }

    public void PalletSpeedUp()
    {

    }

    public void MultiBall()
    {

    }

    public void BlockHP()
    {

    }
}
