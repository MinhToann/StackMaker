using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] Transform target;
    private float speed = 5f;
    void Start()
    {
        offset = transform.position - target.position;
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}
