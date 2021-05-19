using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject modeText;
    public GameObject menuImage;

    public Sprite[] portraitSprites;
    short difficultyMode = 1;

    // Start is called before the first frame update
    void Start()
    {
        menuImage.GetComponent<Image>().sprite = portraitSprites[(int)Random.Range(0, portraitSprites.Length)];
    }

    public void StartPressed()
    {
        
    }

    public void ModePressed()
    {
        //TODO: implement difficulty
        switch (difficultyMode)
        {
            case 0:
                modeText.GetComponent<Text>().text = "Mode: Easy";
                break;
            case 1:
                modeText.GetComponent<Text>().text = "Mode: Medium";
                break;
            case 2:
                modeText.GetComponent<Text>().text = "Mode: Hard";
                difficultyMode = -1; //roll around
                break;
            default:
                break;
        }

        difficultyMode++;
    }
}
