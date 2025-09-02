using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Player : MonoBehaviour
{
    [Header("Settings")]
    private bool onCloud = true;
    public float JumpForce;

    //���� ������ �ܼ��� ���� ���� �̵�
    private Transform currentPlatform;
    private float lastPlatformX;



    public int rainbow = 0;


    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public GameObject Restart;


    //Game2Clear
    public GameObject clear;

    //rainbow
    public GameObject rainbow1;
    public GameObject rainbow2;
    public GameObject rainbow3;


    // Update is called once per frame
    void Update()
    {
        Move();
        Die();
    }

    void LateUpdate()
    {
        if (onCloud && currentPlatform != null)
        {
            float dx = currentPlatform.position.x - lastPlatformX;
            if (Mathf.Abs(dx) > 0f)
                transform.position += new Vector3(dx, 0f, 0f);

            lastPlatformX = currentPlatform.position.x;
        }
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && onCloud)
        {
            PlayerRigidBody.AddForce(new Vector2(0, 4f) * JumpForce, ForceMode2D.Impulse);
            //transform.position = new Vector2(transform.position.x, transform.position.y + 2f);   //position �� �����ϴ� �ͺ��� ���� �� �� ���� ������ �� �ڿ�������. 
            onCloud = false;
            currentPlatform = null; // �����ϸ� �÷��� ���� ����
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = new Vector2(transform.position.x - 0.02f, transform.position.y);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud"))
        {
            onCloud = true;
            currentPlatform = collision.transform;
            lastPlatformX = currentPlatform.position.x; // ������ �ʱ�ȭ
        }

        //Game2 Clear
        if (collision.gameObject.name == "Game2Clear" && rainbow == 3)
        {
            clear.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.name == "Game2Clear" && rainbow != 3)
        {
            Restart.SetActive(true);
            gameObject.SetActive(false);
        }


        //������ �浹
        if (collision.gameObject.CompareTag("rainbow"))
        {
            rainbow += 1;
            Destroy(collision.gameObject);
            if (rainbow == 1)
                rainbow1.SetActive(true);
            else if (rainbow == 2)
                rainbow2.SetActive(true);
            else if (rainbow == 3)
                rainbow3.SetActive(true);

        }

        if (collision.gameObject.CompareTag("eagle"))
        {
            Destroy(collision.gameObject);
            Restart.SetActive(true);
            gameObject.SetActive(false);
        }


    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud"))
        {
            // ���� ���� ���ִ� ���� ����
            onCloud = true;
            if (currentPlatform == null)
            {
            {
                currentPlatform = collision.transform;
                lastPlatformX = currentPlatform.position.x;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud") && collision.transform == currentPlatform)
        {
            onCloud = false;
            currentPlatform = null;
        }
    }


    void Die()
    {
        if (gameObject.transform.position.y < -12)
        {
            Restart.SetActive(true);
            gameObject.SetActive(false);
        }

    }

}
