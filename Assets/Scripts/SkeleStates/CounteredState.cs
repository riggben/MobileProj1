using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounteredState : State
{

    public float counteredStunTime = 1f;
    
    public ChaseState chaseState;
    
    public EnemyController enemyCont;

    private float t;
    
    

    public override State RunCurrentState()
    {
        t += Time.deltaTime;
        
        Countered();

        if(t < counteredStunTime)
            return this;
        else
        {
            return chaseState;
        }
    }

    public override State OnStateEnter()
    {

        enemyCont.gameObject.GetComponent<Animator>().SetTrigger("Countered");
        t = 0;
        return null;
    }

    private void Countered()
    {
        //Countered logic
    }
}
