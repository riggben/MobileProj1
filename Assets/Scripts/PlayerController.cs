/*
 * Character controller; a little over-complicated. Consider a state machine.
 */

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
    
    
    //Components
    public VirtualJoystick joystick;
    public Animator anim;
    public EnemyTracker enemyTracker;
    
    
    
    void Start()
    {
        joystick = this.GetComponent<VirtualJoystick>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        HandleAnim();
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


    IEnumerator Counter(Transform enemy)
    {
        enemy.GetComponent<EnemyController>().Countered();
        
        while (counter)
        {
            transform.LookAt(enemy);

            Vector3 towardsPlayer = transform.position - enemy.position;
            Vector3 attackPoint = enemy.position + towardsPlayer.normalized;
            
            transform.position = Vector3.Lerp(transform.position, attackPoint, 1f);
            yield return null;
        }
    }
    

    
    
    //called by anim event
    void AttackEnd()
    {
        anim.SetBool("Attack", false);
        
        counterTarget.GetComponent<EnemyController>().Dead();
    }
}
