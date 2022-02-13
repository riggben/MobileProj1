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

    public EnemyController enemyCont;

    private void Start()
    {
        enemyCont = GetComponent<EnemyController>();
    }

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
            SwitchToNextState(nextState);
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
