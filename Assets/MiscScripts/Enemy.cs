using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    ScoreController score;
    public int scoreWorth;

    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRate;
    public int currentHealth = 3;
    public bool spin = false;
    int spinSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spinSpeed = (int)Random.Range(-200, 200);
        score = GameObject.Find("ScoreController").GetComponent<ScoreController>();

    }

        // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, -ySpeed);
        if(spin) {
            transform.Rotate(0, 0, Time.deltaTime*spinSpeed);
        }
    }

    public int DamageMe(int damage) {
        currentHealth -= damage;
        if(currentHealth <= 0) {
            Die();
        }
        return currentHealth;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") { //if collide with player, die
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D col) { //if out of bounds disappear
        if (col.gameObject.tag == "Bounds")
        {
            score.addToCurrentScore(-(scoreWorth/5));
            Destroy(gameObject);
        }
    }

    void Die() //Death function
    {
        score.addToCurrentScore(scoreWorth);
        Destroy(gameObject);
    }
}