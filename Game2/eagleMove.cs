using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagleMove : MonoBehaviour
{
    [Header("Settings")]
    //좌우 움직임
    public float rightMax = 8.0f;
    public float leftMax = -8.0f;
    private float startPositionX;
    public float direction = 5.0f; //이동속도 + 방향 
    private float minX, maxX;
    private float currentPositionX;

    //독수리 이미지 변경
    public Sprite rightEagle;
    public Sprite leftEagle;

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

        if (currentPositionX > maxX)  //
        {
            direction *= -1; //왼쪽으로 방향 전환
            currentPositionX = maxX;
            GetComponent<SpriteRenderer>().sprite = leftEagle;


        }
        else if (currentPositionX < minX)
        {
            direction *= -1; //오른쪽으로 방향 전환
            currentPositionX = minX;
            GetComponent<SpriteRenderer>().sprite = rightEagle;
        }
        transform.position = new Vector3(currentPositionX, transform.position.y, transform.position.z);

    }
}
