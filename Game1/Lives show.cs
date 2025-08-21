using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livesshow : MonoBehaviour
{

    [Header("References")]
    public Game1Player life;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life.lives == 2)
            life3.SetActive(false);
        else if (life.lives == 1)
            life2.SetActive(false);
        else if (life.lives == 0)
            life1.SetActive(false);

    }
}
