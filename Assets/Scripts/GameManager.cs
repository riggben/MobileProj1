using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Player;
    public EnemyTracker enemyTracker;
    public float MusicVolume = 0.5f;
    public float volumeScale = 0.5f;
    private GameData gd;

    private void Start()
    {

        gd = GameObject.Find("GameData").GetComponent<GameData>();

        float vol = MusicVolume * gd.volumeScale;

        if (gd.mute)
            vol = 0f;

        Camera.main.GetComponent<AudioSource>().volume = vol;

        volumeScale = gd.volumeScale;
        
        Player = GameObject.Find("Specter3");
        enemyTracker = GameObject.Find("EnemyTracker").GetComponent<EnemyTracker>();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

 


}
