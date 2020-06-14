using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    private Camera mainCam;

    public float speed = 6f;
    public float gravityNorm = -9.81f;
    public float gravity;
    public float jumpH = 2;

    public float lockedZ;
    public float lockedX;

    public float z;
    public float x;

    public Transform groundCheck;

    public Transform wallCheckLeft;
    public Transform wallCheckRight;

    public float groundDistance = 0.4f;
    public float wallDistance = 0.3f;

    public bool isGrounded;
    public bool isWallLeft;
    public bool isWallRight;

    public bool isSliding = false;
    public bool canMove = true;

    public Vector3 velocity;
    public Vector3 movement;

    public LayerMask groundChecks;


    private void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {

        if (canMove)
        {

            WallRun();

            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("c"))
            {
                speed = 11f;
            }
            else
            {
                speed = 6f;
            }
        }
        if (isSliding)
        {
            StartCoroutine("Slide");
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundChecks);
       
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }


        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        if (canMove)
        {
            movement = transform.right * x + transform.forward * z;
        }
        else if (!canMove)
        {
            movement = transform.right * lockedX + transform.forward * lockedZ;
        }


        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown("space") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpH * -2f * gravity);
        }
        if (Input.GetKeyDown("c") && !isSliding)
        {
            transform.localScale = new Vector3(1,0.5f,1);
            if (z > 0.5f && Input.GetKey(KeyCode.LeftShift))
            {
                isSliding = true;
            }
        }
        else if(Input.GetKeyUp("c") )
        {
            transform.localScale = new Vector3(1, 1, 1);
            isSliding = false;
            canMove = true;
        }

    }


    private void WallRun()
    {
        isWallLeft = Physics.CheckSphere(wallCheckLeft.position, wallDistance, groundChecks);
        isWallRight = Physics.CheckSphere(wallCheckRight.position, wallDistance, groundChecks);

        if ((isWallLeft || isWallRight) && velocity.y < 0)
        {
            gravity = -5f;
        }
        else
        {
            gravity = gravityNorm;
        }


    }

    IEnumerator Slide()
    {
        isSliding = false;
        LockMovement();
        speed = 15f;
        yield return new WaitForSeconds(0.4f);
        canMove = true;
        isSliding = false;
        canMove = true;
    }

    void LockMovement()
    {
        lockedZ = z;
        lockedX = x;
        canMove = false;

    }
}