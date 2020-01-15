using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : Enemy
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float playerDistance = 25.0f;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    private BoxCollider2D head;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Health = startHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        head = gameObject.GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<PlayerHealth>().isDead)
        {
            if (Vector2.Distance(transform.position, player.position) < playerDistance)
            {
                if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                }

                if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) < 10.0f)
                {
                    StartCoroutine(shooting());
                    timeBtwShots = startTimeBtwShots;

                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }else
        {
            enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(2);
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
    IEnumerator shooting()
    {
        animator.SetBool("isShooting", true);
        Vector3 pom = transform.position;
        pom.x -= 0.3f;
        Instantiate(projectile, pom, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("isShooting", false);
        
    }
}
