using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health;
    public int Health { get { return health; } set { health = value; } }
    // Start is called before the first frame update
    void Start()
    {
        Health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
