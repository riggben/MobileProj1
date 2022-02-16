using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState_Specter : State
{

    public State idleState, dodgeState;
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

        playerCont.HandleMovement();

        if (joystick.ButtonDown)
        {
            return dodgeState;
        }
        else if (joystick.Joystick.magnitude < 0.01f)
        {
            return idleState;
        }
        else
        {
            return null;
        }
    }


    
}
