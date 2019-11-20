using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(JumpLogic());
        //rigidbody.AddForce(new Vector2(0, 1200));
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
        float minWaitTime = 5f;
        float maxWaitTime = 10f;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
            if (Health <= 0) break;
            rigidbody.AddForce(new Vector2(0, 1200));
        }
    }
}
