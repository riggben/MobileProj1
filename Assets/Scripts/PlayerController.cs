using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Parameters
    public float moveSpeed = 10.0f;
    
    //Public variables
    public bool counter = false;
    
    //Components
    public VirtualJoystick joystick;
    public Animator anim;


    void Start()
    {
        joystick = this.GetComponent<VirtualJoystick>();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        if (joystick.ButtonDown)
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

        if (joystick.ButtonDown)
        {
            counter = true;
            anim.SetTrigger("Counter");
        }
        else
        {
            counter = false;
        }
    }

    void HandleAction()
    {
        
    }

    void HandleAnim()
    {
        anim.SetFloat("Run", joystick.Joystick.magnitude);
    }
}
