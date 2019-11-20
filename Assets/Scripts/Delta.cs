﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delta : Enemy
{
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;
    private BoxCollider2D head;

    // Start is called before the first frame update
    void Start()
    {
        Health = startHealth;
        transform.Rotate(0f, 180f, 0f);
        head = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, 0.1f, layerMask);

        if(!groundInfo.collider)
        {
            if(movingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                movingRight = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0f);
                movingRight = true;
            }
        }

        if(wallInfo.collider)
        {
            if (movingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                movingRight = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0f);
                movingRight = true;
            }
        }
       
        if(head.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            takeDamage(10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(10);
            StartCoroutine(onPlayerHit());
        }
    }

    private IEnumerator onPlayerHit()
    {
        transform.Rotate(0f, 180f, 0f);
        yield return new WaitForSeconds(0.5f);
        transform.Rotate(0f, 180f, 0f);
    }
}
