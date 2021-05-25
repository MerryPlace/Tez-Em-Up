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
        myController.SwitchBoardPressed(0); 
    }

    // Update is called once per frame
    void Update()
    {

        // movement controls//

        Vector3 targetPos;
        if(Input.touchCount > 0) //if touching screen
        {
            for (int i = 0; i < Input.touchCount ; i++) 
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                if(targetPos.y > -3 && (!bovineMode||!firing)) 
                {
                    targetPos.y = transform.position.y;
                    targetPos.z = 0;
                    transform.position = Vector3.MoveTowards(
                        transform.position, targetPos, speed * Time.deltaTime);
                }            
            }      
        }
        else if(Input.GetMouseButton(0)) //using mouse click
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (targetPos.y > -3 && (!bovineMode||!firing))
            {
                targetPos.y = transform.position.y;
                targetPos.z = 0;
                transform.position = Vector3.MoveTowards(
                    transform.position, targetPos, speed * Time.deltaTime);
            }
        }

        checkForKeyPress();
        
        if(firing) 
        {
            triedToFire = true;
        }
    }

    void checkForKeyPress() 
    {
        // button controls//

        //fire keyboard controls
        if (Input.GetKey("space")) //pressing fire
        {
            ActionPressed();
        }
        if (Input.GetKeyUp("space")) //released fire
        {
            ActionReleased();
        }    

        //char change keyboard controls
        if (Input.GetKeyDown("t") || Input.GetKeyDown("1")) 
        {
            myController.SwitchBoardPressed(0); 
        }
        else if (Input.GetKeyDown("k") || Input.GetKeyDown("2")) 
        {
            myController.SwitchBoardPressed(1); 
        }
        else if (Input.GetKeyDown("d") || Input.GetKeyDown("3")) 
        {
            myController.SwitchBoardPressed(2); 
        }
        else if (Input.GetKeyDown("c") || Input.GetKeyDown("4")) 
        {
            myController.SwitchBoardPressed(3); 
        }
        else if (Input.GetKeyDown("b") || Input.GetKeyDown("5")) 
        {
            myController.SwitchBoardPressed(4); 
        }
        else if (Input.GetKeyDown("o") || Input.GetKeyDown("6")) 
        {
            myController.SwitchBoardPressed(5); 
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
