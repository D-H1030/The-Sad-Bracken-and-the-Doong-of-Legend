using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Spawner : MonoBehaviour
{
    [Header("References")]
    public GameObject[] gameObjects;
    //public Game1Player game1player;

    [Header("Settings")]
    public float minSpawnDelay;
    public float maxSpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }


    void Spawn()
    {
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
