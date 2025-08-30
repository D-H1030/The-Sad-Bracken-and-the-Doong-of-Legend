using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{

    [Header("References")]
    public GameObject cloud;

    [Header("Settings")]
    public float minSpawnDelay;
    public float maxSpawnDelay;

    void Start()
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }


    void Spawn()
    {
        Instantiate(cloud, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
