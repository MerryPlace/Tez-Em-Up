using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerWeapon : MonoBehaviour
{
        PlayerShip myShip;
    public GameObject[] projectiles;
    int shotCounter = 0;

    public float inComboDelay = .3f;
    public float betweenComboDelay = 1f;

    bool shouldDelayFire = true;

    // Start is called before the first frame update
    void Start()
    {
        myShip = transform.parent.GetComponent<PlayerShip>();
        InvokeRepeating("AttemptShot",0f,inComboDelay);
        StartCoroutine(DelayFire(inComboDelay/2));
    }

    void AttemptShot()
    {
        if (myShip.triedToFire && !shouldDelayFire)
        {
            Instantiate(projectiles[shotCounter], myShip.triggerA.transform.position, Quaternion.identity);
            shotCounter++;
            myShip.triedToFire = false;

            if(shotCounter == 3) {
                shotCounter = 0;
                shouldDelayFire = true;
                StartCoroutine(DelayFire(betweenComboDelay));
            }
        }
    }

    IEnumerator DelayFire(float time)
    {
        yield return new WaitForSeconds(time);
        shouldDelayFire = false;
    }

}
