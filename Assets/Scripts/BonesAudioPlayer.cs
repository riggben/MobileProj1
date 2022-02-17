using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesAudioPlayer : MonoBehaviour
{
    public AudioClip bones;
    public float bonesVolume = 1f;

    public GameManager gm;
    public GameData gd;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        GameObject.Find("GameData").GetComponent<GameData>();
    }

    public void BonesSound()
    {
        GameObject.Find("GameData").GetComponent<GameData>();
        gm = FindObjectOfType<GameManager>();
        GetComponent<AudioSource>().PlayOneShot(bones, gm.volumeScale * bonesVolume);
    }
}
