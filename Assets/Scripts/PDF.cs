using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDF : MonoBehaviour
{
    public PlayerShooting playerShooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerShooting.canShoot = true;
            Destroy(gameObject);
        }
    }
}
