using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    int currentScore;
    void Start()
    {
        currentScore = 0;
        InvokeRepeating("TimeBonus", 2f, 1f);
    }

    void TimeBonus() {
    currentScore++;
    }

    public int getCurrentScore() {
        return currentScore;
    }

    public void addToCurrentScore(int addition) {
        currentScore += addition;
    }
}
