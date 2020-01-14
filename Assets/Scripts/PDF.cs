using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDF : MonoBehaviour
{
    public PlayerShooting playerShooting;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerShooting.canShoot = true;
            playerShooting.crosshair.SetActive(true);
            playerShooting.setBullet(5);
            Destroy(gameObject);
        }
    }
}
