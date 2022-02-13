using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public IdleState idleState;
    public CounteredState counteredState;
    
    public EnemyController enemyCont;

    public override State RunCurrentState()
    {
        Chase();

        if (enemyCont.countered)
        {
            return counteredState;
        }
        else if (enemyCont.inAttackRange || enemyCont.isAttacking)
        {
            return attackState;
        }
        else if(enemyCont.canSeePlayer)
        {
            return this;
        }
        else
        {
            return idleState;
        }
    }

    private void Chase()
    {
        enemyCont.Chase();
    }
}
