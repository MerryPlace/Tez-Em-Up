using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerWeapon : MonoBehaviour
{
    public GameObject[] projectiles;
    int shotCounter = 0;
    
    PlayerShip myShip;
    int framesSinceLastShot = 0;
    public int baseDelay = 60;
    int delay = 0;

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
            Instantiate(projectiles[shotCounter %3], myShip.triggerA.transform.position, Quaternion.identity);
            framesSinceLastShot = 0;
            shotCounter++;

            if(shotCounter %3 == 0) {
                delay = baseDelay*3;
            }
            else {
                delay = baseDelay;
            }
        }
    }
}
