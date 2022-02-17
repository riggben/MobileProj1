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
    private Animator anim;
    private float t;
    private void Start()
    {
        playerCont = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
    }

    public override State OnStateEnter()
    {
        anim.SetTrigger("Dodge");
        playerCont.dodging = true;
        playerCont.invulnerable = true;
        t = 0f;
        return null;
    }
    
    public override State RunCurrentState()
    {

        Vector3 dodgeDirection = transform.forward;

        t += Time.deltaTime;
        player.transform.position += dodgeDirection * Time.deltaTime * dodgeDistance;

        
        if(playerCont.dodging)
        {
            return null;
        }
        else
        {
            playerCont.invulnerable = false;
            return runState;
        }
  
    }


    
}