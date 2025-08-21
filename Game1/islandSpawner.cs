using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject[] gameObjects;

    [Header("Settings")]
    public float islandSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", islandSpawnTime);
    }


    void Spawn()
    {
        GameObject gameObject = gameObjects[0];
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }

}
