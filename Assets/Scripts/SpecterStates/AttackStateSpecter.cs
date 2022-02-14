using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateSpecter : State
{
    public float attackDistance = 2f;
    
    public State idleState;

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

        Vector3 awayFromEnemy = playerCont.counterTarget.transform.position - player.transform.position;
        player.transform.position += awayFromEnemy.normalized * attackDistance;
        player.transform.LookAt(playerCont.counterTarget.transform);
        anim.SetBool("Attack", true);
        
        return null;
    }
    
    public override State RunCurrentState()
    {


        if (anim.GetBool("Attack"))
        {
            return null;
        }
        else
        {
            return idleState;
        }
    }


}