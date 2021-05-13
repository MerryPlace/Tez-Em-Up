using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheetahWeaponry : MonoBehaviour
{
    public GameObject bulletPrefab;
    PlayerShip myShip;
    int framesSinceLastShot = 0;
    public int delay = 60;

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
            Instantiate(bulletPrefab, myShip.triggerA.transform.position, Quaternion.identity);
            framesSinceLastShot = 0;
        }
        
    }
}
