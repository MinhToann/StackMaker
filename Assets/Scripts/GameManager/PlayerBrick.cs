using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrick : MonoBehaviour
{
    
    [SerializeField] Transform parent;
    [SerializeField] GameObject playerModel;
    [SerializeField] GameObject Brick;
    [SerializeField] Transform brickPosInPlayer;
    List<GameObject> listStack = new List<GameObject>();
    [SerializeField] Transform modelPos;
    private GameObject BrickPlayer;
    private GameObject eatBrickPlayer;
    Vector3 posY = new Vector3(0, 0, 0);
    public static PlayerBrick instance;
    float brickHeight = 0.3f;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        OnInit();
    }
    private void OnInit()
    {
        BrickPlayer = Instantiate(Brick);
        listStack.Add(BrickPlayer);
        BrickPlayer.transform.position = brickPosInPlayer.position;
        BrickPlayer.transform.SetParent(parent);
        playerModel.transform.position = modelPos.position;
        posY = new Vector3(0, 0, 0);
    }
    public void CallOnInit()
    {
        OnInit();
    }    
    public void AddStack()
    {
        eatBrickPlayer = Instantiate(Brick, transform);
        listStack.Add(eatBrickPlayer);     
        eatBrickPlayer.transform.SetParent(parent);
        posY.y += 0.3f;
        eatBrickPlayer.transform.localPosition = new Vector3(0, -posY.y - 0.3f , 0);
        Vector3 posParent = playerModel.transform.position;
        posParent.y += brickHeight;
        playerModel.transform.position = posParent;
        Debug.Log("2");
    }
    public void DestroyStack()
    {
        Destroy(listStack[listStack.Count - 1].gameObject);
        listStack.Remove(listStack[listStack.Count - 1]);
        posY.y -= 0.3f;
        Vector3 posParent = playerModel.transform.localPosition;
        posParent.y -= brickHeight;
        playerModel.transform.localPosition = posParent;
    }
    public void ClearStack()
    {
        for(int i = listStack.Count - 1; i >= 0; i--)
        {
            Destroy(listStack[i].gameObject);
            //listStack.Remove(listStack[i]);
        }
        listStack.Clear();
    }
}
