using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5f;
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
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
