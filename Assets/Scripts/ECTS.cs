using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECTS : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().heal(amount);
            Destroy(gameObject);
        }
    }
}
