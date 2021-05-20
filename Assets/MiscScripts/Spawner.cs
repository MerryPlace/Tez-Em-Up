using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float baseSpawnRate;
    public GameObject[] enemies;
    public float sr;

    AppController appController;

    // Start is called before the first frame update
    void Start()
    {
        appController = GameObject.Find("AppController").GetComponent<AppController>();
        sr = baseSpawnRate - (appController.difficultyMode * .3f);
        InvokeRepeating("Spawn", 0, sr);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0f), Quaternion.identity);
    }
}
