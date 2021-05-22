using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    //Score weights
    int defeatWorth = 25;
    int missWorth = 5;
    int timeBonusWorth = 1;

    // Actively changing during 
    int currentScore;
    float timeStart;
    int enemiesDefeated;
    int enemiesMissed;

    //final values
    public int finalScore;
    public float finalTime;
    public int finalKilled;
    public int finalMissed; 

    void Start()
    {
        timeStart = Time.time;
        currentScore = 0;
        InvokeRepeating("TimeBonus", 1f, 1f);
    }
    void TimeBonus() {
        addToCurrentScore(timeBonusWorth);
    }

    public void calcFinalScores() {
        finalTime = Time.time - timeStart;
        finalKilled = enemiesDefeated;
        finalMissed = enemiesMissed;
        finalScore = currentScore;
    }

    public int getCurrentScore() {
        return currentScore;
    }
    void addToCurrentScore(int addition) {
        currentScore += addition;
    }

    public void enemyDefeated() {
        enemiesDefeated++;
        addToCurrentScore(defeatWorth);
    }
    public void enemyMissed() {
        enemiesMissed++;
        addToCurrentScore(-missWorth);
    }



    
}
