using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startHealth;
    private int health;
    public int Health { get { return health; } set { health = value; } }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
