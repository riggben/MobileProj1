using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public PlayerController playerCont;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            playerCont.coins++;
            Destroy(other.gameObject);
        }
    }
}
