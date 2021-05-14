using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Melee : MonoBehaviour
{
    public int damage = 2;

    void Awake() {
        GetComponent<PolygonCollider2D>().enabled = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().DamageEnemy(damage);
        }
    }
}
