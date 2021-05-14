using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWeapon : MonoBehaviour
{
    public GameObject axePrefab;
    PlayerShip myShip;
    int framesSinceLastSwing = 0;
    int chargeSpeed = 90;

    bool attacking = false;
    bool chargeSwingMode = true;

    int framesUntilSwing = 650;
    int framesUntilDeath = 1650; //950

    GameObject axe;


    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attacking) {
            framesSinceLastSwing++;
            if(chargeSwingMode) {
                axe.transform.RotateAround(myShip.triggerCenter.transform.position, Vector3.back, chargeSpeed * Time.deltaTime);
                if(framesSinceLastSwing > framesUntilSwing) {
                    chargeSwingMode = false;
                    axe.transform.localScale = new Vector3(2f,2f,1);
                    axe.GetComponent<SpriteRenderer>().color = Color.red;
                    axe.GetComponent<PolygonCollider2D>().enabled = true;
                    
                }
            } else {
                axe.transform.RotateAround(myShip.triggerCenter.transform.position, Vector3.forward, chargeSpeed * 2.5f * Time.deltaTime);
                
                if(framesSinceLastSwing > framesUntilDeath) {
                    Destroy(axe,0);
                    attacking = false;
                }

            }
        } else if(myShip.firing) {

            attacking = true;
            chargeSwingMode = true;
            framesSinceLastSwing = 0;

            axe = Instantiate(axePrefab, transform.position, axePrefab.transform.rotation, gameObject.transform);
        }
    }
}
