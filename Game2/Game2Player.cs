using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Player : MonoBehaviour
{
    [Header("Settings")]
    private bool onCloud = true;
    public float JumpForce;

    //구름 위에서 잔숭이 구름 따라 이동
    private Transform currentPlatform;
    private float lastPlatformX;


    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public GameObject Restart;


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
            PlayerRigidBody.AddForce(new Vector2(0, 2f) * JumpForce, ForceMode2D.Impulse);
            //transform.position = new Vector2(transform.position.x, transform.position.y + 2f);   //position 을 조작하는 것보다 힘을 줄 때 점프 동작이 더 자연스럽다. 
            onCloud = false;
            currentPlatform = null; // 점프하면 플랫폼 추적 해제
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
            lastPlatformX = currentPlatform.position.x; // 기준점 초기화
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cloud"))
        {
            // 구름 위에 서있는 동안 유지
            onCloud = true;
            if (currentPlatform == null)
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
        if (transform.position.y < -12)
            Restart.SetActive(true);
    }

}
