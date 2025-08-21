using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class islandStop : MonoBehaviour
{
    [Header("References")]
    public Game1Mover game1mover;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 6)
        {
            game1mover.moveSpeed = 0;
        }
    }
}
