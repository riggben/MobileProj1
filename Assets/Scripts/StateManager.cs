/*
 * Benjamin Rigg
 * Simple state machine
 * based on https://www.youtube.com/watch?v=cnpJtheBLLY - Sebastian Graves
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public State currentState;
    


    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToNextState(nextState);
            currentState.OnStateEnter();
        }
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
    
    public void SetState(State state)
    {
        currentState = state;
    }
}
