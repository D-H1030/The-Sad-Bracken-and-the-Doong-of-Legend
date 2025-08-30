using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [Header("Settings")]
    //좌우 움직임
    public float rightMax = 2.0f;
    public float leftMax = -2.0f;
    private float startPositionX;
    public float direction = 3.0f; //이동속도 + 방향 
    private float minX, maxX;
    private float currentPositionX;

    void Start()
    {
        startPositionX = transform.position.x;  //구름의 맨 처음 위치
        minX = startPositionX + leftMax;
        maxX = startPositionX + rightMax;
    }

    // Update is called once per frame
    void Update()
    {
        LeftAndRight();
    }

    void LeftAndRight()
    {
        currentPositionX = transform.position.x + direction * Time.deltaTime;

        if (currentPositionX > maxX)
        {
            direction *= -1; //방향 전환
            currentPositionX = maxX;
        }
        else if (currentPositionX < minX)
        {
            direction *= -1;
            currentPositionX = minX;
        }
        transform.position = new Vector3(currentPositionX, transform.position.y, transform.position.z);

    }
}
