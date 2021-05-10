using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMoveTest : MonoBehaviour
{
    public Transform target;
    private float speed = 5;
    Vector3 tarPos;

    private void Start()
    {
        tarPos = target.position;
    }
    void Update()
    {
        Vector3 playerPos = transform.position;
        Vector3 dirToTarget = tarPos - playerPos;
        dirToTarget.y = 0;
        Quaternion lookAtTargetRot = Quaternion.LookRotation(dirToTarget);
        //Vector3 moveVector = lookAtTargetRot *
        //                     new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) *
        //                     speed * Time.deltaTime;
        //transform.position += moveVector;     
        Vector3 moveVector = lookAtTargetRot *
                             new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

       transform.Translate(moveVector* speed * Time.deltaTime);
    }
}
