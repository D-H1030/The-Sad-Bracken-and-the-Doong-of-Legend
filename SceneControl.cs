using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public int SceneNumber;

    void OnMouseDown()
    {
        SceneManager.LoadScene(SceneNumber + 1);
    }
}
