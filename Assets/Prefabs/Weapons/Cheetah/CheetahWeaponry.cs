using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetahWeaponry : MonoBehaviour
{
    public GameObject bulletPrefab;
    PlayerShip myShip;
    public float shotDelay = 10f;


    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();
        InvokeRepeating("AttemptShot",0f,shotDelay);
    }

    void AttemptShot()
    {
        if (myShip.triedToFire)
        {
            Instantiate(bulletPrefab, myShip.triggerA.transform.position, Quaternion.identity);
            myShip.triedToFire = false;
        }
    }
}
