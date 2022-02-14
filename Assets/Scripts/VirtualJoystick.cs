using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour
{
    public float stickSize = 1.0f;

    public Vector2 Joystick = Vector2.zero;
    public bool isJoystick = false;
    [FormerlySerializedAs("DodgeTrigger")] public bool ButtonDown = false;
    public float Magnitude = 0;

    public bool debug = false;

    public GameObject JoystickCenter;
    public Canvas canvas;

    Vector2 JoystickStart = Vector2.zero;
    Vector2 JoystickPresent = Vector2.zero;
    Vector2 VirtualJoystickData = Vector2.zero;

    Touch touch0, touch1;

    public bool OnFirstTouch = false;
    bool TouchOnPrevFrame = false;
    bool SecondTouchOnPrevFrame = false;

    GameObject currentJoystickCenter;

    private void Start()
    {
        currentJoystickCenter = Instantiate(JoystickCenter, canvas.transform);
        currentJoystickCenter.transform.position = new Vector3(-1000, -1000, 1);
    }

    void Update()
    {


        if (Input.touchCount > 0)
        {
            touch0 = Input.GetTouch(0);
            isJoystick = true;

            JoystickPresent = touch0.position;
            if (Input.touchCount > 1)
            {
                touch1 = Input.GetTouch(1);
            }

        }
        else
        {
            JoystickPresent = JoystickStart;
            isJoystick = false;
        }


        //handle OnFirstTouch
        if (!TouchOnPrevFrame && Input.touchCount > 0)
        {
            OnFirstTouch = true;
            OnTouch();
        }
        else
            OnFirstTouch = false;

        //handle OnSecondTouch
        if (!SecondTouchOnPrevFrame && Input.touchCount > 1)
        {
            ButtonDown = true;

        }
        else
            ButtonDown = false;

        //Virt Joystick data                  |center of joystick           |where the joystick is currently held           |Current magnitude of JS
        //Debug.Log($"JoystickStatus: Center:({JoystickStart}) Current Pos: ({JoystickPresent}) Distance: ({Vector2.Distance(JoystickStart, JoystickPresent)}) ");

        //We now have the necessary numbers for a virtual joystick. let's acutally make it
        VirtualJoystickData = JoystickPresent - JoystickStart;
        if (debug) Debug.Log("Raw VJS Data: " + VirtualJoystickData);
        //This is now the raw vector showing where the control is pointing- but the magnitude is effectively infinite
        //this will be a problem for larger screens, or screens with a higher resolution!

        VirtualJoystickData = (VirtualJoystickData * (1f / (((float)Screen.height * (float)Screen.width))) * 10000f * stickSize);
        //Debug.Log((1f / (((float)Screen.height * (float)Screen.width))) * 10000f);
        if (debug) Debug.Log("Normalized VJS Data: " + VirtualJoystickData);
        /*The values have been normalized based on the current resolution. This not only makes the numbers more manageable, but should help the VJS behave more consistently across different devices
        The Values still are not limited-- It's a good idea to limit the magnitude. The simplest way is to Clamp the x and y values, but that will result in a square pattern, i.e. going diagonal will be faster, root2 instead of 1
        Instead, let's just Normalize() the vector if its magnitude is greater than 1
        */
        if (VirtualJoystickData.magnitude > 1.0f)
            VirtualJoystickData.Normalize();
        if (debug) Debug.Log("Clamped VJS Data: " + VirtualJoystickData);

        //present final data to other classes
        Joystick = VirtualJoystickData;
        Magnitude = Joystick.magnitude;

        //Place a dot at the center of the joystick
        if (isJoystick)
        {
            currentJoystickCenter.transform.position = new Vector3(JoystickStart.x, JoystickStart.y, 1);
        }
        else
        {
            currentJoystickCenter.transform.position = new Vector3(-1000, -10000, 1);
        }
    }

    private void LateUpdate()
    {



        //Make sure this happens at the end of the update cycle
        if (Input.touchCount == 0)
            TouchOnPrevFrame = false;
        else
            TouchOnPrevFrame = true;

        if (Input.touchCount >= 2)
            SecondTouchOnPrevFrame = true;
        else
            SecondTouchOnPrevFrame = false;
    }

    //Called the first frame that the screen is touched (by the first finger)
    void OnTouch()
    {
        JoystickStart = touch0.position;
    }
}
