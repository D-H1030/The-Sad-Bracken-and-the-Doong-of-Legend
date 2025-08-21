using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Game1Player : MonoBehaviour
{

    public int lives = 3;
    private bool isInvincible = false;

    [Header("References")]
    public GameObject Restart;
    public GameObject GameClear;

    //扁夯 儡件, 公利 惑怕 儡件 备盒
    public Sprite BasicJansung;
    public Sprite InvincibleJansung;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        ForceToBack();

    }

    void Move()
    {
        if (lives != 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                transform.position = new Vector2(transform.position.x, transform.position.y + 2.5f * Time.deltaTime);

            else if (Input.GetKey(KeyCode.DownArrow))
                transform.position = new Vector2(transform.position.x, transform.position.y - 2.5f * Time.deltaTime);

            else if (Input.GetKey(KeyCode.LeftArrow))
                transform.position = new Vector2(transform.position.x - 2.5f * Time.deltaTime, transform.position.y);

            else if (Input.GetKey(KeyCode.RightArrow))
                transform.position = new Vector2(transform.position.x + 2.5f * Time.deltaTime, transform.position.y);
        }

    }

    void ForceToBack()
    {
        if (lives > 0)
            transform.position = new Vector2(transform.position.x - 1f * Time.deltaTime, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (lives > 0)
        {
            if (collider.gameObject.tag == "obstacle")
            {
                if (!isInvincible)
                {
                    Destroy(collider.gameObject);
                    Hit();
                }
            }
            else if (collider.gameObject.tag == "oar")
            {
                Destroy(collider.gameObject);
                StartInvincible();
            }
            else if (collider.gameObject.tag == "island")
            {
                GameClear.SetActive(true);
                gameObject.SetActive(false);
            }
        }

    }

    void Hit()
    {
        lives -= 1;
        if (lives == 0)
        {
            Die();
        }
    }

    void StartInvincible()
    {
        isInvincible = true;
        GetComponent<SpriteRenderer>().sprite = InvincibleJansung;
        Invoke("StopInvincible", 7f);
    }

    void StopInvincible()
    {
        isInvincible = false;
        GetComponent<SpriteRenderer>().sprite = BasicJansung;
    }

    void Die()
    {
        Restart.SetActive(true);
    }
}
