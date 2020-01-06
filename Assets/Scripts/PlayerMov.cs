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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        canJump = true;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
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
                StartCoroutine(Jump());
            }
        }
    }


    void Move(float horizontal)
    {
        rigidbody2D.velocity = new Vector2(horizontal * Speed, rigidbody2D.velocity.y);
        animator.SetFloat("Walk", Mathf.Abs(horizontal));
    }


    void Flip(float horizontal)
    {
        if (horizontal > 0 && !faceRight || horizontal < 0 && faceRight)
        {
            faceRight = !faceRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    IEnumerator Jump()
    {
        animator.SetBool("Jump", true);
        rigidbody2D.AddForce(Vector2.up * JumpHeight);
        yield return new WaitForSeconds(0.45f);
        animator.SetBool("Jump", false);
    }


}
