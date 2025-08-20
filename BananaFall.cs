using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BananaFall : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D banana;


    void Start()
    {
        banana = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Grass")
        {
            Invoke("Stop", 0.1f);

        }

        if (collision.gameObject.name == "Jansung12")
        {
            banana.AddForce(new Vector2(1f, 1.5f) * 2.5f, ForceMode2D.Impulse);
        }

    }
    void Stop()
    {
        banana.velocity = Vector2.zero;
        banana.angularVelocity = 0f;

    }

    // Update is called once per frame
    void Update()
    {
    }
}
