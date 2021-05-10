using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrlScriptPhisics : MonoBehaviour
{
    Rigidbody rigidbodyPlayer;
    Transform transformPlayer;
    CapsuleCollider colliderPlayer;
    float horizontal;
    float vertical;
    public float speed = 0.25f;
    public float jumpForce = 1f;
    Vector3 moveTo;
    public LayerMask GroundLayer = 0;
    public Transform mountainPos;
    float checkDistance;
    Animator animatorPlayer;
    public float maxVelocity = 1f;
    private bool isGrounded
    {
        get
        {
            Vector3 bottomCenterPoint = new Vector3(colliderPlayer.bounds.center.x, colliderPlayer.bounds.min.y, colliderPlayer.bounds.center.z);

            //создаем невидимую физическую капсулу и проверяем не пересекает ли она обьект который относится к полу

            //_collider.bounds.size.x / 2 * 0.9f -- эта странная конструкция берет радиус обьекта.
            // был бы обязательно сферой -- брался бы радиус напрямую, а так пишем по-универсальнее

            return Physics.CheckCapsule(colliderPlayer.bounds.center, bottomCenterPoint, colliderPlayer.bounds.size.x / 2 * 0.9f, GroundLayer);
            // если можно будет прыгать в воздухе, то нужно будет изменить коэфициент 0.9 на меньший.
        }
    }

    private Vector3 movement
    {
        get
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 currentMovement;
            //Vector3 inputMovement = new Vector3(horizontal, 0.0f, vertical);
            //Vector3 newInputPosition = transformPlayer.position + inputMovement;
            //if (Vector3.Distance(newInputPosition, mountainPos.position) > 31f || Vector3.Distance(newInputPosition, mountainPos.position) < 30f)
            //{
            //    Vector3 correctDistance = (newInputPosition - mountainPos.position).normalized * 30f;
            //    Vector3 currectPosition = mountainPos.position + correctDistance;
            //    currentMovement = currectPosition - transformPlayer.position;
            //} else
                currentMovement = new Vector3(horizontal, 0.0f, vertical);

            return currentMovement;
        }
    }

    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        transformPlayer = GetComponent<Transform>();
        colliderPlayer = GetComponent<CapsuleCollider>();
        animatorPlayer = GetComponentInChildren<Animator>();
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        //checkDistance = transformPlayer.position.z - mountainPos.position.z;
        animatorPlayer.SetBool("Walk", false);
    }
    private void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        //moveTo = new Vector3(horizontal, 0, vertical) * Time.deltaTime * speed;
        //transform.position = transform.position + moveTo;

        //}
        //эти строчки гарантирют что наш скрипт не завалится если на плеере будет отсутствовать нужные компоненты
        //[RequireComponent(typeof(Rigidbody))]
        //[RequireComponent(typeof(CapsuleCollider))]

        //transform.LookAt(movement);


    }
    void FixedUpdate()
    {
        Jumping();
        Moving();
    }

    private void Moving()
    {
        if (isGrounded && movement != Vector3.zero)
        {

            rigidbodyPlayer.AddForce(movement * speed, ForceMode.Impulse);
            //rigidbodyPlayer.AddForce(movement * speed, ForceMode.Force);

            //if (Vector3.Distance(transformPlayer.position, mountainPos.position) > 31f || Vector3.Distance(transformPlayer.position, mountainPos.position) < 29f)
            //{
            //    Vector3 cor1 = (transformPlayer.position - mountainPos.position).normalized * 30f;
            //    transformPlayer.position = mountainPos.position + cor1;
            //}

            animatorPlayer.SetBool("Walk", true);
            rigidbodyPlayer.velocity = Vector3.ClampMagnitude(rigidbodyPlayer.velocity, maxVelocity);
        }
        else
            animatorPlayer.SetBool("Walk", false);
    }

    private void Jumping()
    {
        if (isGrounded && (Input.GetAxis("Jump") > 0))
        {
            rigidbodyPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

}
