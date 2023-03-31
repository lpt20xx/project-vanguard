using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] protected float moveSpeed = 5f;

    //get key
    [SerializeField] protected float verticalMove;
    [SerializeField] protected float horizontalMove;

    protected float verticalPos;
    protected float horizontalPos;

    [Header("Jump")]
    [SerializeField] protected Rigidbody playerRb;
    protected float thrust = 7f;

    //jump
    [SerializeField] protected float jump;
    [SerializeField] protected float jumpForce = 1f;
    [SerializeField] protected float jumpHeight = 2.5f;

    protected Vector3 jumpVector3;
    protected bool isGrounded;

    [Header("Animator")]
    [SerializeField] protected Animator animator;

    private void Start()
    {
        this.isGrounded = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        this.GetInputAxis();
        this.PlayerPos();
        this.PlayerMoving();
        this.PlayerJump();
    }

    protected void GetInputAxis()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");

        if (PlayerHealth.isDead)
        {
            moveSpeed = 0f;
            verticalMove = 0f;
            horizontalMove = 0f;
            jump = 0f;
            return;
        }

        
        
    }

    protected void PlayerPos()
    {
        verticalPos = horizontalMove * moveSpeed * Time.deltaTime;
        horizontalPos = verticalMove * moveSpeed * Time.deltaTime;
    }

    protected virtual void PlayerMoving()
    {
        this.transform.Translate(new Vector3(verticalPos, 0, horizontalPos));
    }
    protected void OnCollisionStay()
    {
        isGrounded = true;
    }

    protected virtual void PlayerJump()
    {
        jumpVector3 = new Vector3(0, jumpHeight, 0);
        if(jump > 0 && isGrounded)
        {
            playerRb.AddForce(jumpVector3 * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    
}
