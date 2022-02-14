using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CounterState_Specter : State
{
    public float counterTime = 1f;
    public float counterDistance = 5f;
    
    public State attackState, idleState;
    public GameObject player;
    
    private PlayerController playerCont;
    private Animator anim;
    private VirtualJoystick joystick;

    private float t;
    
    private void Start()
    {
        playerCont = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
        joystick = playerCont.joystick;
    }

    public override State OnStateEnter()
    {
        t = 0;

        Vector3 awayFromEnemy = player.transform.position - playerCont.counterTarget.transform.position;
        player.transform.position += awayFromEnemy.normalized * counterDistance;
        player.transform.LookAt(playerCont.counterTarget.transform);
        anim.SetTrigger("Counter");
        
        return null;
    }
    
    public override State RunCurrentState()
    {
        t += Time.deltaTime;
        
           



        if (joystick.ButtonDown || joystick.OnFirstTouch)
        {
            return attackState;
        }
        else if (t >= counterTime)
        {
            return idleState;
        }
        else
        {
            return null;
        }
    }



}