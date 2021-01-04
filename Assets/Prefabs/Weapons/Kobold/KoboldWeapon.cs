using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldWeapon : MonoBehaviour
{
    public GameObject bullet;
    PlayerShip myShip;
    int framesSinceLastShot = 0;
    public int delay = 10;

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
            Instantiate(bullet, myShip.triggerA.transform.position, Quaternion.identity);
            framesSinceLastShot = 0;
        }
    }
}
