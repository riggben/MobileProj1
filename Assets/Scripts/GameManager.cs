using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public EnemyTracker enemyTracker;


    private void Start()
    {
        Player = GameObject.Find("Specter3");
        enemyTracker = GameObject.Find("EnemyTracker").GetComponent<EnemyTracker>();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

 


}
