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
    
    //Components
    public VirtualJoystick joystick;
    public Animator anim;
    public EnemyTracker enemyTracker;
    
    private bool movementLocked = false;
    private bool isDodging = false;
    private int dodges = 0;
    
    void Start()
    {
        joystick = this.GetComponent<VirtualJoystick>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if(!movementLocked && !isDodging && !counter)
            HandleMovement();
        if (joystick.ButtonDown && !isDodging && !counter)
            HandleAction();
        
        HandleAnim();
    }

    void HandleMovement()
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

    void HandleAction()
    {
        counter = false;

        GameObject counterTarget = CanCounter();
        
        if (counterTarget != null)
        {
            //Counter
            counter = true;
            anim.SetTrigger("Counter");
            StartCoroutine(Counter(counterTarget.transform));
            //Debug.Log("SUCCESSFUL COUNTER!");
        }
        else
        {
            //Dodge
            StartCoroutine("Dodge");
        }
    }

    GameObject CanCounter()
    {


        foreach (GameObject g in enemyTracker.NearbyEnemies)
        {
            if (g.GetComponent<EnemyController>().isCounterable)
            {
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
    
    IEnumerator Dodge()
    {
        isDodging = true;
        dodges++;
        Vector3 dodgeDirection = transform.forward;
        movementLocked = true;
        for (float t = 0f; t < dodgeTime; t += Time.deltaTime)
        {
            transform.position += dodgeDirection * Time.deltaTime * dodgeDistance;

            yield return null;
        }
        movementLocked = false;
        isDodging = false;
    }
    
    
    //called by anim event
    void AttackEnd()
    {
        //Debug.Log("Counter Ended");
        counter = false;
    }
}
