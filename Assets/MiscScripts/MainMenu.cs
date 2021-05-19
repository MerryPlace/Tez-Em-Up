using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject modeText;
    public GameObject menuImage;

    public Sprite[] portraitSprites;
    short difficultyMode = 0;

    // Start is called before the first frame update
    void Start()
    {
        menuImage.GetComponent<Image>().sprite = portraitSprites[(int)Random.Range(0, portraitSprites.Length)];
        modeText.GetComponent<Text>().text = ModeCodeText();
    }

    public void StartPressed()
    {
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        
        while (asyncLoad.isDone == false)
        {
            yield return null;
        }
    }

    public void ModePressed()
    {
        difficultyMode++;
        if(difficultyMode == 3) {
            difficultyMode = 0;
        }
        //TODO: implement difficulty
        modeText.GetComponent<Text>().text = ModeCodeText();

    }

    string ModeCodeText() 
    {
        switch (difficultyMode)
        {
            case 0:
                return "Mode: Easy";
            case 1:
                return "Mode: Medium";
            case 2:
                return "Mode: Hard";
            default:
                return "Mode: Error";
        }
    }
}
