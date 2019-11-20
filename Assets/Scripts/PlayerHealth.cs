﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthUI;
    private bool isInvincible;
    private int health;
    public int Health { get { return health; } set { health = value; } }

    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        Health = 30;
        isInvincible = false;
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = health + "/30";
    }

    public void takeDamage(int amount)
    {
        if (!isInvincible)
        {
            Health -= amount;
            if (health <= 0)
            {
                Destroy(gameObject);
                restartButton.SetActive(true);
            }
                
        }
    }

    public void heal(int amount)
    {
        if (amount + health > 30) Health = 30;
        else Health += amount;
    }

    public void becomeInvincible()
    {
        StartCoroutine(invincible());
    }

    private IEnumerator invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(4f);
        isInvincible = false;
    }
}
