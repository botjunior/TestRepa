using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsScript : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed;
    Rigidbody rb;
    Transform tr;
    Vector3 moveTo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveTo = new Vector3(horizontal, 0, vertical)*Time.deltaTime* speed;
        tr.position = tr.position + moveTo;
    }
}
