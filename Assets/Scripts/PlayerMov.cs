using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float Speed;
    private bool faceRight;
    public Joystick joystick;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        Move(horizontal);
        Flip(horizontal);
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
}
