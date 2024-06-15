using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    string winState = "Win";
    string idleState = "Idle";
    string currentState;
    [SerializeField] Animator anim;
    private void Start()
    {
        OnInit();
    }
    private void OnInit()
    {
        ChangeStatement(idleState);
    }
    void Update()
    {
        if (PlayerMovement.instance.isWin)
        {
            ChangeStatement(winState);
        }
        else
        {
            OnInit();
        }
    }
    private void ChangeStatement(string newState)
    {
        if (currentState != newState)
        {
            anim.ResetTrigger(currentState);
            currentState = newState;
            anim.SetTrigger(currentState);
        }
    }
}
