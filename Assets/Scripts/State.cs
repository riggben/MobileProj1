/*
 * Benjamin Rigg
 * Simple state machine
 * based on https://www.youtube.com/watch?v=cnpJtheBLLY - Sebastian Graves
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract State RunCurrentState();
}
