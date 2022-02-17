using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameOverMenuManager : MonoBehaviour
{

    public void Retry()
    {
        SceneManager.LoadScene(GameObject.Find("GameData").GetComponent<GameData>().prevScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    

}
