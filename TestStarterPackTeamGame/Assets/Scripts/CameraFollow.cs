using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraFollowPos;
    Vector3 destination;
    public float easing = 0.05f;
    public Transform playerPosition;
    void Start()
    {
        transform.position = cameraFollowPos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // destination = Vector3.Lerp(transform.position, cameraFollowPos.position, easing);    // перемещаем на 5% в каждом вызове FixedUpdate (а он 50 раз в секунду)
        //transform.position = destination;

        transform.position = cameraFollowPos.position;
        transform.LookAt(playerPosition);
    }
}
