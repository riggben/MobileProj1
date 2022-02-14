using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;

    public EnemyController enemyCont;

    public override State RunCurrentState()
    {
        Idle();

        if (enemyCont.canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    public override State OnStateEnter()
    {
        return null;
    }
    
    private void Idle()
    {
        enemyCont.Idle();
    }
}
