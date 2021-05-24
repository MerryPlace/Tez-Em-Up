using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShip : MonoBehaviour
{
    public Controller myController;

    SpriteRenderer mySR;
    public float speed;

    bool bovineMode;

    //invulnerability vars
    public float invulTime;
    bool invulnerable = false;

    //weapon variables
    [HideInInspector] public GameObject triggerA;
    [HideInInspector] public GameObject triggerB;
    [HideInInspector] public GameObject triggerCenter;
    GameObject currentWeapon;
    public GameObject TWeapon;
    public GameObject KWeapon;
    public GameObject DWeapon;
    public GameObject CWeapon;
    public GameObject BArrow;
    public GameObject OCannon;
    [HideInInspector] public bool firing = false;
    [HideInInspector] public bool triedToFire; //so one tap will result in one shot after delay

    public void ActionPressed()
    {
        firing= true;
    }
    public void ActionReleased()
    {
        firing= false;
    }

    public void switchWeapon(int tez) 
    {
        if(currentWeapon != null) {
            Destroy(currentWeapon);
        }

        bovineMode = false;

        switch (tez)
        {
            case 0:
                currentWeapon = Instantiate(TWeapon, triggerA.transform.position, Quaternion.identity);
                break;
            case 1:
                currentWeapon = Instantiate(KWeapon, triggerA.transform.position, Quaternion.identity);
                break;
            case 2:
                currentWeapon = Instantiate(DWeapon, triggerCenter.transform.position, Quaternion.identity);
                break;
            case 3:
                currentWeapon = Instantiate(CWeapon, triggerA.transform.position, Quaternion.identity);
                break;
            case 4:
                bovineMode = true;
                currentWeapon = Instantiate(BArrow, triggerA.transform.position, Quaternion.identity);
                break;
            case 5:
                currentWeapon = Instantiate(OCannon, triggerB.transform.position, Quaternion.identity);
                break;
            default:
                Debug.Log("Error: Tried to switch to non-existent weapon.");
                break;
        }
        if(currentWeapon != null) {
            currentWeapon.transform.parent = gameObject.transform;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if(myController == null) {
            myController  = GameObject.Find("Level Controller").GetComponent<Controller>();
        }
        mySR = GetComponent<SpriteRenderer>();
        triggerA = transform.Find("triggerA").gameObject;
        triggerB = transform.Find("triggerB").gameObject;
        triggerCenter = transform.Find("triggerCenter").gameObject;
        switchWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && (!bovineMode||!firing) )
        {
            
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (targetPos.y > -3)
            {
                targetPos.y = transform.position.y;
                targetPos.z = 0;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
        }
        if(firing) 
        {
            triedToFire = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (!invulnerable)
            {
                myController.DamagePlayer();
                if (myController.getPlayerHealth() == 0)
                {
                    myController.PlayerDeath();
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
