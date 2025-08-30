using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [Header("Settings")]
    //�¿� ������
    public float rightMax = 2.0f;
    public float leftMax = -2.0f;
    private float startPositionX;
    public float direction = 3.0f; //�̵��ӵ� + ���� 
    private float minX, maxX;
    private float currentPositionX;

    void Start()
    {
        startPositionX = transform.position.x;  //������ �� ó�� ��ġ
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
            direction *= -1; //���� ��ȯ
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
