using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECTS : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().heal(amount);
            Destroy(gameObject);
        }
    }
}
