using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text modeText;
    public Image menuImage;

    public Text creditVerText;

    AppController appController;

    public Sprite[] portraitSprites;
    short difficultyMode;

    // Start is called before the first frame update
    void Start()
    {
        appController = GameObject.Find("AppController").GetComponent<AppController>();
        difficultyMode = appController.difficultyMode;
        creditVerText.text = "Ver " + Application.version + "\nNoah Ortega";
        
        menuImage.sprite = portraitSprites[(int)Random.Range(0, portraitSprites.Length)];
        modeText.text = ModeCodeText();
    }

    public void StartPressed()
    {
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        appController.difficultyMode = difficultyMode;
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
