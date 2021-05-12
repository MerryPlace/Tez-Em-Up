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
    
    int framesSinceLastShot = 0;
    public int shotDelay;
    public int chargeInterval;
    public float maxRotateSpeed;
    public float minRotateSpeed;
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
            framesCharging++;

            float rotateSpeed = Time.deltaTime*framesCharging;
            if(rotateSpeed > maxRotateSpeed) {
                rotateSpeed = maxRotateSpeed;
        }
            transform.Rotate(0, 0, rotateSpeed);

            if(framesCharging % chargeInterval == 0) {
                Debug.Log(rotateSpeed);
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

            if(!myShip.firing) {
                charging = false;
                mySR.enabled = false;
                Instantiate(projectiles[projectileLevel], myShip.triggerB.transform.position, Quaternion.identity).GetComponent<CannonBall>().rotateSpeed = rotateSpeed;
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