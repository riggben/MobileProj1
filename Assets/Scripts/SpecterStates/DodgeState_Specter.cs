using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState_Specter : State
{

    public float dodgeTime = .5f, dodgeDistance = 10f; 
    
    public State runState;
    public GameObject player;

    private PlayerController playerCont;
    
    private float t;

    private void Start()
    {
        playerCont = player.GetComponent<PlayerController>();
    }

    public override State OnStateEnter()
    {
        playerCont.invulnerable = true;
        t = 0f;
        return null;
    }
    
    public override State RunCurrentState()
    {

        Vector3 dodgeDirection = transform.forward;

        t += Time.deltaTime;
        player.transform.position += dodgeDirection * Time.deltaTime * dodgeDistance;

        if (t >= dodgeTime)
        {
            playerCont.invulnerable = false;
            return runState;
        }
        else
        {
            return null;
        }
    }


    
}