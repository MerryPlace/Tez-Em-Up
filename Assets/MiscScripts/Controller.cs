using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public UIManager myUI;
    public PlayerShip myShip;
    public ScoreController myScore;
    int health = 3;
    
    // Start is called before the first frame update
    void Start() {
        if(myShip == null) {
            myShip  = GameObject.Find("Tezinol Ship").GetComponent<PlayerShip>();
        }
        SwitchBoardPressed(0);
    }

    public void SwitchBoardPressed(int buttonNum) {
        Debug.Log("pressed " + buttonNum);
        myUI.UpdateSwitchBoard(buttonNum);
        myShip.switchWeapon(buttonNum);
    }

    public void exitToMenuPressed() {
        StartCoroutine(ReturnToMenu()); 
    }

    public void DamagePlayer() {
        health--;
        myUI.UpdateHealth(health);
    }

    public int getPlayerHealth() {
        return health;
    }

    public void PlayerDeath() {
        myScore.calcFinalScores();
        myUI.onGameOver();
        Destroy(myShip.gameObject);
    }

    IEnumerator ReturnToMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        
        while (asyncLoad.isDone == false)
        {
            yield return null;
        }
    }
}
