using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Sprite[] portraits;
    public GameObject portraitUI;
    public Sprite[] highlights;
    public GameObject switchUI;
    public Sprite[] hearts;
    public GameObject heartUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateSwitchBoard(int buttonNum)
    {
        portraitUI.GetComponent<Image>().sprite = portraits[buttonNum];
        switchUI.GetComponent<Image>().sprite = highlights[buttonNum];
    }
}
