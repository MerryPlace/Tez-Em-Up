using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ScoreController scores;

    //Control console
    public Sprite[] portraits;
    public GameObject portraitUI;
    public Sprite[] highlights;
    public GameObject switchUI;
    public Sprite[] hearts;
    public GameObject heartUI;
    public Button[] consoleButtons;
    public Text consoleScoreUI;

    //GameOver console
    public GameObject mainMenuUI;
    public Text[] gameOverStatText;
    public Image[] gameOverStatTrophies;

    void Start()
    {
        mainMenuUI.SetActive(false);
        foreach(Image i in gameOverStatTrophies) {
            i.enabled = false;
        } //TODO: implement trophies


        InvokeRepeating("UpdateScoreUI", 0f, .5f);
    }

    void UpdateScoreUI() {
        consoleScoreUI.text = "Score "+ scores.getCurrentScore();
    }

    public void UpdateSwitchBoard(int buttonNum)
    {
        portraitUI.GetComponent<Image>().sprite = portraits[buttonNum];
        switchUI.GetComponent<Image>().sprite = highlights[buttonNum];
    }

    public void UpdateHealth(int health)
    {
        heartUI.GetComponent<Image>().sprite = hearts[health];
    }

    public void onGameOver() {
        foreach (Button b in consoleButtons) {
            b.interactable = false;
        }
        CancelInvoke();
        consoleScoreUI.text = "Score "+ scores.finalScore;
        gameOverStatText[0].text = "Time " + (Mathf.Round(scores.finalTime * 100)) / 100.0 + " sec";
        gameOverStatText[1].text = "Missed " + scores.finalMissed + " baddies";
        gameOverStatText[2].text = "Killed " + scores.finalKilled + " baddies";
        gameOverStatText[3].text = "Score " + scores.finalScore;

        mainMenuUI.SetActive(true);
    }


}
