
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoStoryManager : MonoBehaviour
{
    public static AutoStoryManager instance;

    public GameObject[] stories;
    public float interval = 1f;

    public GameObject StoryManager;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(NextStory());
    }


    IEnumerator NextStory()
    {
        foreach (var s in stories) s.SetActive(false);  //모든 스토리 끄기
        for (int i = 0; i < stories.Length; i++)
        {
            stories[i].SetActive(true);
            yield return new WaitForSeconds(interval);
            stories[i].SetActive(false);
        }
        enabled = false;
        StoryManager.SetActive(true);
    }

}