using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagleMove : MonoBehaviour
{
    [Header("Settings")]
    //�¿� ������
    public float rightMax = 8.0f;
    public float leftMax = -8.0f;
    private float startPositionX;
    public float direction = 5.0f; //�̵��ӵ� + ���� 
    private float minX, maxX;
    private float currentPositionX;

    //������ �̹��� ����
    public Sprite rightEagle;
    public Sprite leftEagle;

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

        if (currentPositionX > maxX)  //
        {
            direction *= -1; //�������� ���� ��ȯ
            currentPositionX = maxX;
            GetComponent<SpriteRenderer>().sprite = leftEagle;


        }
        else if (currentPositionX < minX)
        {
            direction *= -1; //���������� ���� ��ȯ
            currentPositionX = minX;
            GetComponent<SpriteRenderer>().sprite = rightEagle;
        }
        transform.position = new Vector3(currentPositionX, transform.position.y, transform.position.z);

    }
}
