using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    GameObject Player;
    bool isPush = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null && isPush)
        {
            if (Vector3.Dot(Player.transform.forward, transform.forward) > 0.5f)
            {
                Player.transform.forward = -transform.right;
                isPush = false;
            }
            else if (Vector3.Dot(Player.transform.forward, transform.right) > 0.5f)
            {
                Player.transform.forward = -transform.forward;
                isPush = false;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPush = true;
            Player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPush = false;
            Player = null;
        }
    }
}
