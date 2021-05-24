using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonWeapon : MonoBehaviour
{
    public GameObject axePrefab;
    PlayerShip myShip;
    int chargeSpeed = 90;

    bool attacking = false;
    bool chargeSwingMode = true;

    public float timeUntilSwing = 1.8f;
    public float timeUntilDestroy = 4f; 

    float nextTimeToAct;

    GameObject axe;

    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attacking) 
        {
            if(chargeSwingMode) //slow charge up
            {
                axe.transform.RotateAround(myShip.triggerCenter.transform.position, Vector3.back, chargeSpeed * Time.deltaTime);

                if(Time.time > nextTimeToAct) //proceed to next phase
                {
                    chargeSwingMode = false;
                    nextTimeToAct += timeUntilDestroy;
                    axe.transform.localScale = new Vector3(2f,2f,1);
                    axe.GetComponent<SpriteRenderer>().color = Color.red;
                    axe.GetComponent<PolygonCollider2D>().enabled = true;
                    
                }
            } 
            else //long circular attack
            {
                axe.transform.RotateAround(myShip.triggerCenter.transform.position, Vector3.forward, chargeSpeed * 3.5f * Time.deltaTime);
                
                if(Time.time > nextTimeToAct) //Destroy axe
                {
                    Destroy(axe,0);
                    attacking = false;
                }

            }
        } 
        else if(myShip.firing) //begin attack sequence
        {

            attacking = true;
            chargeSwingMode = true;
            nextTimeToAct = Time.time + timeUntilSwing;

            axe = Instantiate(axePrefab, transform.position, axePrefab.transform.rotation, gameObject.transform);
        }
    }
}
