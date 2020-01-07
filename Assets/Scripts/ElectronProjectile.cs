using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronProjectile : MonoBehaviour
{
    private float speed = 10.0f;
    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().takeDamage(15);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
