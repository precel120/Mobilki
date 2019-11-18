using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isInvincible;
    private int health;
    public int Health { get { return health; } set { health = value; } }
    // Start is called before the first frame update
    void Start()
    {
        Health = 30;
        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount)
    {
        if (!isInvincible)
        {
            Health -= amount;
            if (health <= 0) Destroy(gameObject);
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
        yield return new WaitForSeconds(2f);
        isInvincible = false;
    }
}
