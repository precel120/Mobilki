using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthUI;
    private bool isInvincible;
    public Text endGameText;
    public ParticleSystem invincibility;
    public bool isDead = false;
    private SpriteRenderer playerVisibility;

    private int health;
    public int Health { get { return health; } set { health = value; } }

    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        playerVisibility = gameObject.GetComponent<SpriteRenderer>();
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
                isDead = true;
                StartCoroutine(gameOver());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndGame")
        {
            StartCoroutine(gameWon());
        }
        if(collision.gameObject.tag == "GameOver")
        {
            StartCoroutine(gameOver());
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
        invincibility.Play();
        isInvincible = true;
        yield return new WaitForSeconds(4f);
        isInvincible = false;
        invincibility.Stop();
    }

    private IEnumerator gameOver()
    {
        playerVisibility.enabled = false;
        yield return new WaitForSeconds(1f);
        endGameText.text = "Unfortunately, you didn't manage to graduate";
        yield return new WaitForSeconds(2f);
        endGameText.text = "Do you want to try again?";
        restartButton.SetActive(true);
    }

    private IEnumerator gameWon()
    {
        yield return new WaitForSeconds(0.5f);
        endGameText.text = "Cogratulations! You've made it past the first semester";
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        endGameText.text = "Do you want to reapeat it?";
        restartButton.SetActive(true);
    }

}
