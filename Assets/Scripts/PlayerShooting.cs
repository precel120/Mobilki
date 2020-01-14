using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    public Transform fireSpot;
    public GameObject pencil, ruler;
    private float fireCooldown, fireCooldownDuration = 0.0f;
    public bool canShoot;
    public int bulletAmount;
    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        fireCooldown = 0.6f;
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (bulletAmount == 0)
            {
                canShoot = false;
                crosshair.SetActive(false);
            }
        }
        if (Time.time > fireCooldownDuration)
        {
            if (CrossPlatformInputManager.GetButtonDown("Shoot") && canShoot)
            {
                int randomChoice = Random.Range(0, 2);
                if (randomChoice == 1)
                {
                    Instantiate(ruler, fireSpot.position, fireSpot.rotation);
                }
                else
                {
                    Instantiate(pencil, fireSpot.position, fireSpot.rotation);
                }
                fireCooldownDuration = Time.time + fireCooldown;
                bulletAmount--;
            }
        }
    }

    public void setBullet(int amount)
    {
        bulletAmount = amount;
    }
}
