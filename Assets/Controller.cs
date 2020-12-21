using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject myUIGO;
    UIManager myUI;

    int health = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        myUI = myUIGO.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActionPressed()
    {
        Debug.Log("You have clicked the Action!");
    }

    public void SwitchBoardPressed(int buttonNum)
    {
        myUI.UpdateSwitchBoard(buttonNum);
    }

    public void Damage() {
        health--;
        myUI.UpdateHealth(health);
    }

    public int getHealth() {
        return health;
    }

}
