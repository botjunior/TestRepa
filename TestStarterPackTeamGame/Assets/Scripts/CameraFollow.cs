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
        // destination = Vector3.Lerp(transform.position, cameraFollowPos.position, easing);    // ���������� �� 5% � ������ ������ FixedUpdate (� �� 50 ��� � �������)
        //transform.position = destination;

        transform.position = cameraFollowPos.position;
        transform.LookAt(playerPosition);
    }
}
