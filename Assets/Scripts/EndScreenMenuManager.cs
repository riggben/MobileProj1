using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenMenuManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
