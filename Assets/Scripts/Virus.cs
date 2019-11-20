using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    private Rigidbody2D rigidbody;
    private bool movingRight = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Health = startHealth;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(JumpLogic());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            takeDamage(15);
            collision.gameObject.GetComponent<PlayerMov>().canJump = false;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1400));
            collision.gameObject.GetComponent<PlayerMov>().canJump = true;
        }
    }

    IEnumerator JumpLogic()
    {
        float minWaitTime = 1f;
        float maxWaitTime = 5f;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
            if (Health <= 0) break;

            float randDir = Random.Range(-150, 150);
            if(randDir > 0)
            {
                randDir += 150;
            }else
            {
                randDir -= 150;
            }

            if (movingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                rigidbody.AddForce(new Vector2(randDir, 700));
                movingRight = false;
            }
            else
            {
                transform.Rotate(0f, 180f, 0f);
                rigidbody.AddForce(new Vector2(randDir, 700));
                movingRight = true;
            }
        }
    }
}
