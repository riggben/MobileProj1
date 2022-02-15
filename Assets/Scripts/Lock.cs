using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject FallenLock;
    
    public void Unlock()
    {
        GetComponent<Animator>().SetTrigger("Unlock");      
        
    }

    private void FallOff()
    {
        Instantiate(FallenLock, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
