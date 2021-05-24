using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeapon : MonoBehaviour
{
    public Sprite[] sprites;
    public Color[] spriteColors;
    public GameObject[] projectiles;
    PlayerShip myShip;
    SpriteRenderer mySR;
    
    public float chargeInterval;
    public int rotateSpeed;
    int projectileLevel = 0;
    bool charging;

    float timeToNextCharge;


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

        if(charging) //continue charging
        {
            //set rotation amount
            transform.Rotate(0, 0, rotateSpeed * (projectileLevel+1) * Time.deltaTime);

            //projectile level upgrades
            if(projectileLevel != 2 && Time.time > timeToNextCharge)
            {
                timeToNextCharge+= chargeInterval;

                projectileLevel++;
                mySR.sprite = sprites[projectileLevel];
                mySR.color = spriteColors[projectileLevel];
            }

            //if player has released button to fire, fire
            if(!myShip.firing) 
            {
                charging = false;
                mySR.enabled = false;
                Instantiate(projectiles[projectileLevel], myShip.triggerB.transform.position, Quaternion.identity)
                    .GetComponent<CannonBall>().rotateSpeed = rotateSpeed * (projectileLevel+1) * Time.deltaTime;
            }
        }
        else if (myShip.firing) //begin charging weapon and set first projectile level
        {
            charging = true;
            timeToNextCharge = Time.time + chargeInterval;

            projectileLevel = 0;
            mySR.sprite = sprites[projectileLevel];
            mySR.color = spriteColors[projectileLevel];
            mySR.enabled = true;
        }
    }
}