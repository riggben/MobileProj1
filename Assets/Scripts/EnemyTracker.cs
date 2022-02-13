/*
 * This weird little script can keep track of what enemies are within countering range. Adjust the radius of the trigger/collider on the EnemyTracker GameObject to adjust counter range.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public List<GameObject> NearbyEnemies;

    private void Start()
    {
        NearbyEnemies = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            NearbyEnemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            NearbyEnemies.Remove(other.gameObject);
        }
    }
}
