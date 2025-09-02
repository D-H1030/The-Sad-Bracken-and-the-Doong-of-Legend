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
            if (cloud == null) continue; // 이미 파괴된 구름은 비교 안 함.
            if (cloud.transform.position.y < gameObject.transform.position.y)
                Destroy(cloud);
        }

        foreach (GameObject eagle in eagles)
        {
            if (eagle == null) continue; // 이미 파괴된 독수리는 비교 안 함.
            if (eagle.transform.position.y < gameObject.transform.position.y)
                Destroy(eagle);
        }
    }

}
