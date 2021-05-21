using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 5;
    public int damage = 1;
    Vector2 velocity;
    Rigidbody2D rb;

    void Awake() {
        rb=GetComponent<Rigidbody2D>();
        velocity = new Vector2(0,speed);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().DamageMe(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
