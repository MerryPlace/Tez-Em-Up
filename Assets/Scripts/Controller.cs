using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject myUIGO;
    UIManager myUI;
    public GameObject myShipGO;
    PlayerShip myShip;
    [HideInInspector] public int tez = 0;
    int health = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        myUI = myUIGO.GetComponent<UIManager>();
        myShip = myShipGO.GetComponent<PlayerShip>();
    }

    public void SwitchBoardPressed(int buttonNum)
    {
        myUI.UpdateSwitchBoard(buttonNum);
        myShip.switchWeapon(buttonNum);
    }

    public void Damage() {
        health--;
        myUI.UpdateHealth(health);
    }

    public int getHealth() {
        return health;
    }

}
