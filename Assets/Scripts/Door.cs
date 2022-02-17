using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int numberOfLocks = 3;
    
    public List<GameObject> Locks = new List<GameObject>();

    public string nextLevel = "";
    
    public GameManager gm;
    
    

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        
        for (int i = 0; i < numberOfLocks; i++)
        {
            Locks[i].SetActive(true);
        }
    }

    public void Unlock(int numberToUnlock)
    {
        if (numberToUnlock > numberOfLocks)
            numberToUnlock = numberOfLocks;


        gm.Player.GetComponent<PlayerController>().keys -= numberToUnlock;

        for (int i = 0; i < numberToUnlock; i++)
        {
            Locks[0].GetComponent<Lock>().Unlock();
            Locks.Remove(Locks[0]);
            numberOfLocks--;
        }
        
        

        if (numberOfLocks <= 0)
        {
            Open();
        }
        
    }

    private void Open()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }

    private void LoadNextLevel()
    {
        if(nextLevel != "")
            SceneManager.LoadScene(nextLevel);
        else
        {
            Debug.Log("NO NEXT LEVEL SET!");
        }
    }
}
