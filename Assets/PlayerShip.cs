using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    public GameObject controllerGO;
    Controller myController;

    SpriteRenderer mySR;

    public float speed;

    //invulnerability vars
    public float invulTime;
    bool invulnerable = false;

    //weapon variables
    GameObject trigger;
    public GameObject[] TProjectile;
    public GameObject KProjectile;
    public GameObject DProjectile;
    public GameObject CProjectile;
    public GameObject BProjectile;
    public GameObject[] OProjectile;
    float fireStartTime = 0;
    int framesSinceLastShot=0;
    public int delay = 10;
    bool firing = false;


    public void ActionPressed()
    {
        fireStartTime = Time.time;
        firing= true;
    }
    public void ActionReleased()
    {
        firing= false;
    }

    // Start is called before the first frame update
    void Start()
    {
        myController = controllerGO.GetComponent<Controller>();
        mySR = GetComponent<SpriteRenderer>();
        trigger = transform.Find("triggerA").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        framesSinceLastShot++;
        if(firing && framesSinceLastShot>delay) 
        {
            Instantiate(KProjectile, trigger.transform.position, Quaternion.identity);
            framesSinceLastShot=0;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (targetPos.y > -3)
            {
                targetPos.y = transform.position.y;
                targetPos.z = 0;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (!invulnerable)
            {
                myController.Damage();
                if (myController.getHealth() == 0)
                {
                    Destroy(gameObject);
                }
                StartCoroutine("TriggerInvul");
            }
        }
    }
    IEnumerator TriggerInvul()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulTime);
        invulnerable = false;
    }
}
