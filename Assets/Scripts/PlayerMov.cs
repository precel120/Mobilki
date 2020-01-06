using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMov : MonoBehaviour
{
    public float Speed;
    public bool canJump;
    public float JumpHeight;
    private bool faceRight;
    private int jumpCounter;
    public Joystick joystick;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        canJump = true;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal * Speed;
        Move(horizontal);
        Flip(horizontal);

        if(playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump") && canJump){
                Jump();
            }
        }
    }


    void Move(float horizontal)
    {
        rigidbody2D.velocity = new Vector2(horizontal * Speed, rigidbody2D.velocity.y);
    }


    void Flip(float horizontal)
    {
        if (horizontal > 0 && !faceRight || horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * JumpHeight);
    }
}
