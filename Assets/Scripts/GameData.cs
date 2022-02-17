using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public float volumeScale = 1.0f;
    public bool mute = false;
    
    public string prevScene, currentScene;
    
    public void NewScene()
    {
        prevScene = currentScene;
        currentScene = SceneManager.GetActiveScene().name;
        
    }
    
    
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        prevScene = "StartMenu";
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
