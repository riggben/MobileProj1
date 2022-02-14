using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override State OnStateEnter()
    {
        return null;
    }

    public override State RunCurrentState()
    {
        return null;
    }
}
