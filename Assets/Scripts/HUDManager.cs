using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI LivesText, KeysText, CoinsText;
    public GameManager gm;
    
    private PlayerController playerCont;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        playerCont = gm.Player.GetComponent<PlayerController>();
        
    }

    private void Update()
    {

        UpdateHUD();

    }

    public void UpdateHUD()
    {
        LivesText.text = playerCont.lives.ToString();
        KeysText.text = playerCont.keys.ToString();
        CoinsText.text = playerCont.coins.ToString();
    }
    
    
}
