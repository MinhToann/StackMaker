using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UIElements;


public enum DirectMovement
{
    Forward = 0,
    Back = 1,
    Left = 2,
    Right = 3,
    None = 4
}
public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;
    public DirectMovement direct;
    
    [SerializeField] LayerMask brickLayer;
    
    public Transform checkBrick;
    //[SerializeField] Transform Player;
    public bool isMoving = false;
    
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 directionPos;

    RaycastHit rayToCollider;

    Vector3 Target;
    public bool isWin = false;
    [SerializeField] private float moveSpeed = 15f;
    private void Awake()
    {
        instance = this;       
    }
    void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        isMoving = false;
        isWin = false;
    }
    void Update()
    {
        MoveControl(ref direct);
        HandleMove();   
    }
    

    private void MoveControl(ref DirectMovement direct)
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            directionPos = endPos - startPos;
            float xDirection = Mathf.Abs(directionPos.x);
            float yDirection = Mathf.Abs(directionPos.y);
            if (xDirection > yDirection)
            {
                if(directionPos.x > 0)
                {
                    direct = DirectMovement.Right;
                }
                else
                {
                    direct = DirectMovement.Left;
                }
            }    
            else
            {
                if (directionPos.y > 0)
                {
                    direct = DirectMovement.Forward;
                }
                else
                {
                    direct = DirectMovement.Back;
                }
            }
        } 
    }
  
    private void HandleMove()
    {   
        if(CheckRayCast())
        {
            Target = new Vector3(rayToCollider.collider.transform.position.x, transform.position.y, rayToCollider.collider.transform.position.z);
            if (direct != DirectMovement.None)
            {
                isMoving = true;
                
            }

        }
        else
        {
            if (Vector3.Distance(transform.position, Target) < 0.01f)
            {
                isMoving = false;
            }
        }
        if (!isMoving)
        {
            switch (direct)
            {
                case DirectMovement.Left:
                    transform.forward = -Vector3.right;
                    break;
                case DirectMovement.Right:
                    transform.forward = Vector3.right;
                    break;
                case DirectMovement.Back:
                    transform.forward = -Vector3.forward;
                    break;
                case DirectMovement.Forward:
                    transform.forward = Vector3.forward;
                    break;
                case DirectMovement.None:
                    break;
            }    
        }
        if(isMoving)
        {
            moveSpeed = 15f;
            direct = DirectMovement.None;           
            transform.position = Vector3.MoveTowards(transform.position, Target, moveSpeed * Time.deltaTime);       
        }
    }

    private bool CheckRayCast()
    {
        Physics.Raycast(checkBrick.position , Vector3.down, out rayToCollider, 15f, brickLayer);
        return rayToCollider.collider != null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Winpos"))
        {
            moveSpeed = 0f;
            isWin = true;
        }
    }
  
}
