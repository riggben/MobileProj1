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
        if(!movementLocked && !isDodging)
            HandleMovement();
        if (joystick.ButtonDown && !isDodging)
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
        if (CanCounter())
        {
            //Counter
            counter = true;
            anim.SetTrigger("Counter");
            Debug.Log("SUCCESSFUL COUNTER!");
        }
        else
        {
            //Dodge
            StartCoroutine("Dodge");
        }
    }

    bool CanCounter()
    {
        bool ret = false;

        foreach (GameObject g in enemyTracker.NearbyEnemies)
        {
            if (g.GetComponent<EnemyController>().isCounterable)
            {
                ret = true;
            }
        }

        return ret;
    }

    void HandleAnim()
    {
        anim.SetFloat("Run", joystick.Joystick.magnitude);
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
}
