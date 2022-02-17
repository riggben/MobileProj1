/*
 * Character controller; a little over-complicated. Consider a state machine.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Parameters
    public float moveSpeed = 10.0f;
    public float dodgeTime = 1f, dodgeDistance = 1f;
    
    //Public variables
    public bool counter = false;
    public GameObject counterTarget = null;
    public int coins = 0, lives = 3, keys = 0;
    public bool invulnerable = false;
    public bool dodging = false;
    
    //Components
    public VirtualJoystick joystick;
    public Animator anim;
    public EnemyTracker enemyTracker;
    public GameManager gm;
    
    private Vector3 spawnPosition;
    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        spawnPosition = transform.position;
        joystick = this.GetComponent<VirtualJoystick>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        HandleAnim();
    }

    public void Hurt()
    {
        if(!invulnerable)
            lives--;
        
        anim.SetTrigger("Die");
        
    }

    private void Respawn()
    {
        if (lives >= 1)
        {
            transform.position = spawnPosition;
        }
        else
        {
            //Load Game Over Scene  
            transform.position = spawnPosition;
            gm.GameOver();
        }
    }

    public void HandleMovement()
    {
        Vector3 js = new Vector3(joystick.Joystick.x, 0f, joystick.Joystick.y);
        js *= Time.deltaTime;
        js *= moveSpeed;
        
        if (js.magnitude > 0.001f)
        {
            transform.position += js;
            transform.forward = js.normalized;
        }
        
        
    }

    public GameObject CanCounter()
    {


        foreach (GameObject g in enemyTracker.NearbyEnemies)
        {
            if (g.GetComponent<EnemyController>().isCounterable)
            {
                counterTarget = g;
                return g;
            }
        }

        return null;

    }

    void HandleAnim()
    {
        anim.SetFloat("Run", joystick.Joystick.magnitude);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fallout"))
        {
            invulnerable = false;
            Hurt();
        }
    }


    //called by anim event
    void AttackEnd()
    {
        anim.SetBool("Attack", false);
        
        counterTarget.GetComponent<EnemyController>().Dead();
    }

    private void DodgeEnd()
    {
        dodging = false;
    }
}
