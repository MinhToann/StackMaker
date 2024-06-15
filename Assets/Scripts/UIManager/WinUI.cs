using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject comingPanel;
    public static WinUI instance;
    [SerializeField] Animator Anim;
    string Victory = "Victory";
    string None = "None";
    string Coming = "ComingSoon";
    string currentAnim;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        currentAnim = None;
        SetAnim(currentAnim);
        winPanel.SetActive(false);
        comingPanel.SetActive(false);
    }    
    private void Update()
    {
  
    }
  
    private void SetAnim(string newAnim)
    {
        if(currentAnim != null)
        {
            Anim.ResetTrigger(currentAnim);
            currentAnim = newAnim;
            Anim.SetTrigger(currentAnim);
        }

    }    
    public void ActiveWinPanel()
    {
        SetAnim(Victory);
        winPanel.SetActive(true);        
    }    
    public void ActiveEndPanel()
    {
        SetAnim(Coming);
        comingPanel.SetActive(true);
    }
}
