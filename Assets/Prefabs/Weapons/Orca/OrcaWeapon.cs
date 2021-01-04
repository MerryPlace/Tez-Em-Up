using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaWeapon : MonoBehaviour
{
    public Sprite[] sprites;
    public Color[] spriteColors;
    public GameObject[] projectiles;
    PlayerShip myShip;
    SpriteRenderer mySR;
    
    int framesSinceLastShot = 0;
    public int shotDelay = 400;
    public int chargeInterval = 1000;
    int projectileLevel = 0;
    int framesCharging = 0;
    bool charging;


    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();
        mySR = transform.GetComponent<SpriteRenderer>();
        mySR.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(charging) {
            if(framesCharging % chargeInterval == 0) {
                if(framesCharging == chargeInterval) {
                    projectileLevel = 1;
                    mySR.sprite = sprites[projectileLevel];
                    mySR.color = spriteColors[projectileLevel];
                } else if(framesCharging == chargeInterval*2) {
                    projectileLevel = 2;
                    mySR.sprite = sprites[projectileLevel];
                    mySR.color = spriteColors[projectileLevel];
                }
            }
            framesCharging++;

            if(!myShip.firing) {
                charging = false;
                mySR.enabled = false;

                Debug.Log("Shot a type " + projectileLevel);
                Instantiate(projectiles[projectileLevel], myShip.triggerB.transform.position, Quaternion.identity);
                framesSinceLastShot = 0;
            }
        }
        else {
            framesSinceLastShot++;
            if(myShip.firing && framesSinceLastShot > shotDelay) {
                charging = true;
                framesCharging = 0;
                projectileLevel = 0;
                mySR.sprite = sprites[projectileLevel];
                mySR.color = spriteColors[projectileLevel];
                mySR.enabled = true;
            }   
        }
    }
}