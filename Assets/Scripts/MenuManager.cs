using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public Image muteIcon, unMuteIcon;
    public string levelToLoad;

    public bool muted = false;

    public void ToggleMute()
    {
        muteIcon.gameObject.SetActive(!muteIcon.gameObject.activeSelf);
        unMuteIcon.gameObject.SetActive(!muteIcon.gameObject.activeSelf);
    }

    public void Play()
    {
        
        SceneManager.LoadScene(levelToLoad);
    }
}
