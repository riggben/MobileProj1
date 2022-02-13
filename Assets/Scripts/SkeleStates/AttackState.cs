using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public ChaseState chaseState;
    public IdleState idleState;
    public CounteredState counteredState;
    
    public EnemyController enemyCont;

    public override State RunCurrentState()
    {
        Attack();
        if (enemyCont.countered)
        {
            return counteredState;
        }
        else if (enemyCont.inAttackRange)
        {
            return this;
        }
        else if(enemyCont.canSeePlayer)
        {
            return chaseState;
        }
        else
        {
            return idleState;
        }
    }

    private void Attack()
    {
        //add attack logic
        enemyCont.Attack();
    }
}
