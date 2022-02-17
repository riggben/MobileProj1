using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("GameData").GetComponent<GameData>().NewScene();
    }
    
}
