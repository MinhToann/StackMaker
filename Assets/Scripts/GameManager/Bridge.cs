using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            PlayerBrick.instance.DestroyStack();
            Destroy(gameObject.GetComponent<Bridge>());
        }    
    }
    
}
