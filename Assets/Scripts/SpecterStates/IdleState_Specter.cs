using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState_Specter : State
{

    public State runState, counterState;
    public GameObject player;
    
    private PlayerController playerCont;
    private Animator anim;
    private VirtualJoystick joystick;

    private void Start()
    {
        playerCont = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
        joystick = playerCont.joystick;
    }

    public override State OnStateEnter()
    {
        playerCont.invulnerable = false;
        
        return null;
    }
    
    public override State RunCurrentState()
    {
        Idle();

        if (joystick.OnFirstTouch && playerCont.CanCounter() != null)
        {
            return counterState;
        }
        else if (joystick.Magnitude > 0.001f)
        {
            return runState;
        }
        else
        {
            return null;
        }
    }


    private void Idle()
    {
        //Do idle stuff here
    }
    
}
