using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameOutDestroy : MonoBehaviour
{
    public GameObject[] clouds;
    public GameObject[] eagles;
    void Update()
    {

        foreach (GameObject cloud in clouds)
        {
            if (cloud == null) continue; // �̹� �ı��� ������ �� �� ��.
            if (cloud.transform.position.y < gameObject.transform.position.y)
                Destroy(cloud);
        }

        foreach (GameObject eagle in eagles)
        {
            if (eagle == null) continue; // �̹� �ı��� �������� �� �� ��.
            if (eagle.transform.position.y < gameObject.transform.position.y)
                Destroy(eagle);
        }
    }

}
