using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance;

    public GameObject[] stories;

    public int storyNumber = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //일단 함 추가
        stories[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GeneralTextTyping.IsTyping)
        {
            if (storyNumber >= 0 && storyNumber < stories.Length - 1)
            {
                stories[storyNumber].SetActive(false);
            }

            storyNumber++;

            if (storyNumber < stories.Length)
            {
                stories[storyNumber].SetActive(true);
            }
            else
                enabled = false; //스크립트 비활성화. 마지막 story 이후 불필요한 Update 호출 방지.

        }

    }
}

