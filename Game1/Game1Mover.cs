using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Mover : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
