using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRate;
    public int remainingHealth = 3;
    public bool spin = false;
    int spinSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spinSpeed = (int)Random.Range(-200, 200);
    }

    public int DamageEnemy(int damage) {
        remainingHealth -= damage;
        if(remainingHealth <= 0) {
            Die();
        }
        return remainingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, -ySpeed);
        if(spin) {
            transform.Rotate(0, 0, Time.deltaTime*spinSpeed);
        }
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
            Destroy(gameObject);
        }
    }

    void Die() //Death function
    {
        Destroy(gameObject);
    }
}