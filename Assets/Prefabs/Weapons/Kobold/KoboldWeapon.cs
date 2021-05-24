using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject orbitalPrefab;
    PlayerShip myShip;
    public float shotDelay = 10f;
    public int orbitSpeed = 30;

    GameObject orbitalA;
    GameObject orbitalB;
    

    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();

        //orbital setup
        Vector3 orbitalLocation = myShip.triggerCenter.transform.position;
        orbitalLocation.y += 1f;
        orbitalA = Instantiate(orbitalPrefab, orbitalLocation, Quaternion.identity, gameObject.transform);
        orbitalLocation.y -= 2f;
        orbitalB = Instantiate(orbitalPrefab, orbitalLocation, Quaternion.identity, gameObject.transform);
        orbitalB.GetComponent<SpriteRenderer>().flipY = true;

        //shot setup
        InvokeRepeating("AttemptShot",0f,shotDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //orbitals
        orbitalA.transform.RotateAround(myShip.triggerCenter.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
        orbitalB.transform.RotateAround(myShip.triggerCenter.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);
    }

    void AttemptShot() {
        if (myShip.triedToFire)
        {
            Instantiate(bulletPrefab, myShip.triggerA.transform.position, Quaternion.identity);
            myShip.triedToFire = false;
        }
    }
}
