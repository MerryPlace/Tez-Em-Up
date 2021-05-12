using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Rigidbody2D rb;

    public int speed = 8;
    public int damage;
    Vector2 velocity;
    [HideInInspector] public float rotateSpeed;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, speed);
        rb.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Enemy")
        {
            damage = -col.gameObject.GetComponent<Enemy>().Damage(damage);

            if (damage <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (col.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
    }
}
