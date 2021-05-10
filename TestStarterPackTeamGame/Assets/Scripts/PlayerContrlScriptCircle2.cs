using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrlScriptCircle2 : MonoBehaviour
{
    Rigidbody rigidbodyPlayer;
    Transform transformPlayer;
    CapsuleCollider colliderPlayer;
    float horizontal;
    float vertical;
    public float speed = 1f;
    public float jumpForce = 300f;
    Vector3 moveTo;
    public LayerMask GroundLayer = 0;
    public Transform mountainPos;
    float checkDistance;
    Animator animatorPlayer;
    public float maxVelocity = 1f;
    bool isGrounded;
    public Transform forwardPoint;
    public GameObject skin;

    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        transformPlayer = GetComponent<Transform>();
        colliderPlayer = GetComponent<CapsuleCollider>();
        //animatorPlayer = GetComponent<Animator>();
        animatorPlayer = GetComponentInChildren<Animator>();
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        //checkDistance = transformPlayer.position.z - mountainPos.position.z;
        animatorPlayer.SetBool("Walk", false);
    }
    private void FixedUpdate()
    {
        Jumping();
        Moving();
        
    }
    private void Update()
    {
        //transformPlayer.LookAt(forwardPoint);
        //skin.transform.LookAt(forwardPoint);
        //transformPlayer.Rotate(Vector3.forward);
        //if (!isGrounded)
        //{
        //    animatorPlayer.SetBool("Walk", false);
        //    animatorPlayer.SetBool("Jump", true);
        //    animatorPlayer.SetBool("Jump", false);
        //}
    }
    private void Moving()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // Vector3 currentMovement = new Vector3(horizontal, 0.0f, vertical);
        // transformPlayer.transform.LookAt(transformPlayer.transform.position+currentMovement);
        // transformPlayer.Translate(currentMovement * speed * Time.fixedDeltaTime);
        if (horizontal != 0)
        {
            transform.RotateAround(new Vector3(0f, 0f, 0f), -Vector3.up, horizontal * speed * Time.fixedDeltaTime);
            animatorPlayer.SetBool("Walk", true);
            //Debug.Log("горизонтал не 0");
        } else
            animatorPlayer.SetBool("Walk", false);

    }

    private void Jumping()
    {
        if (isGrounded && (Input.GetAxis("Jump") > 0))
        {
            rigidbodyPlayer.AddForce(Vector3.up * jumpForce);
            animatorPlayer.SetBool("Walk", false);
            if (animatorPlayer.GetBool("Jump"))
            {
                animatorPlayer.SetBool("Jump", false);
                return;
            }
            else animatorPlayer.SetBool("Jump", true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        IsGrounded(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGrounded(collision, false);
    }
    void IsGrounded(Collision coll, bool value)
    {
        if (coll.gameObject.layer == 0)
        {
            isGrounded = value;
        }
    }
}
