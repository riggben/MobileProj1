using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounteredState : State
{
    public ChaseState chaseState;
    
    public EnemyController enemyCont;

    public override State RunCurrentState()
    {
        Countered();

        if(enemyCont.countered)
            return this;
        else
        {
            return chaseState;
        }
    }

    public override State OnStateEnter()
    {
        return null;
    }

    private void Countered()
    {
        //Countered logic
    }
}
