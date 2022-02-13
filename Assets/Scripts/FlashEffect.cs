using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    public float beginningScale = 0f, finishedScale = 1f;

    public float scaleSpeed = 1f;
    
    void Start()
    {
        transform.localScale = Vector3.one * beginningScale;
    }
    
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * scaleSpeed;

        if (transform.localScale.x >= finishedScale)
        {
            Destroy(this.gameObject);
        }
    }
}
