using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0f), Quaternion.identity);
    }
}
