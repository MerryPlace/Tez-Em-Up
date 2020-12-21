using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public GameObject controllerGO;
    Controller myController;

    SpriteRenderer mySR;
    public float speed;
    public float invulTime;
    bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        myController = controllerGO.GetComponent<Controller>();
        mySR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
