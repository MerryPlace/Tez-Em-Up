using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BovineWeapon : MonoBehaviour
{
    public GameObject arrowPrefab;
    PlayerShip myShip;
    GameObject myArrow;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myShip.firing)
        {
            if(myArrow!=null) {
                if (Input.GetMouseButton(0))
                {
                    Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (targetPos.y > -3)
                    {
                        targetPos.y = myArrow.transform.position.y;
                        targetPos.z = 0;
                        myArrow.transform.position = Vector3.MoveTowards(myArrow.transform.position, targetPos, speed * Time.deltaTime);

                    }
                }
            }
            else {
                myArrow = Instantiate(arrowPrefab, myShip.triggerA.transform.position, Quaternion.identity);
                myArrow.GetComponent<Rigidbody2D>().freezeRotation = true; //prevents rotation of arrow TODO:IMPLEMENT SMOOTH ROTATION BASED ON MOVEMENT
            }

        }  
    }
}
