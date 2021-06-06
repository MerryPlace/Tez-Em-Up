using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{   
    public static AppController controller;

    public string appVersion = "Alpha 0.1";
    public short difficultyMode = 0;
    void Awake()
    {
        if  (controller == null) {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this) {
            Destroy(gameObject);
        }
    }
}
