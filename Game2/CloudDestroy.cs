using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDestroy : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cloud"))   //other.tag 보다 빠르고 태그 오타도 잡아준다. 
        {
            Destroy(other.gameObject);
        }
    }
}
