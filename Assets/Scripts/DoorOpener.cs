using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public PlayerController playerCont;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") && playerCont.keys > 0)
        {
            other.GetComponent<Door>().Unlock(playerCont.keys);
            
        }
    }
}
