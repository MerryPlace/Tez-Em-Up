using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaWeapon : MonoBehaviour
{
    public Sprite[] cannons;
    public GameObject[] projectiles;
    PlayerShip myShip;
    int framesSinceLastShot = 0;
    public int delay = 20;


    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        framesSinceLastShot++;
        if (myShip.firing && framesSinceLastShot > delay)
        {
            Instantiate(projectiles[69], myShip.trigger.transform.position, Quaternion.identity);
            framesSinceLastShot = 0;
        }
    }
}