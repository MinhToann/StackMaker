using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int currentLevel = 0;
    //[SerializeField] GameObject Player;
    [SerializeField] PlayerMovement player;
    public static LevelManager instance;
    public bool isNextLv = false;
    [SerializeField] List<Level> Levels;
    [SerializeField] GameObject playerModel;
    private Level currentLevelGO;
    public bool isClick;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        OnLoadLevel(currentLevel);
        OnInit();      
    }
    private void OnInit()
    {
        WinUI.instance.OnInit();
        player.transform.position = currentLevelGO.startPoint.position;
    }
    private void FixedUpdate()
    {
        if(isClick)
        {
            PlayerMovement.instance.isMoving = false;
            isClick = false;
        }
    }
    public void Finish()
    {
        if(PlayerMovement.instance.isWin)
        {
            playerModel.transform.position = currentLevelGO.endPoint.position;
        }        
    }    
    public void PlayAgain()
    {
        isClick = true;
        PlayerMovement.instance.isWin = false;
        OnLoadLevel(currentLevel);
        OnInit();
        PlayerBrick.instance.CallOnInit();
    }    
    public void NextLevel()
    {
        isClick = true;
        PlayerMovement.instance.isWin = false;
        OnLoadLevel(++currentLevel);
        OnInit();
        PlayerBrick.instance.CallOnInit();
        
    }  
    private void OnLoadLevel(int level)
    {
        if (currentLevelGO != null)
        {
            Destroy(currentLevelGO.gameObject);
        }

        if (level < Levels.Count)
        {
            currentLevelGO = Instantiate(Levels[level]);
        }
        else
        {
            WinUI.instance.ActiveEndPanel();
            player.gameObject.SetActive(false);
        }
        
    }
}
