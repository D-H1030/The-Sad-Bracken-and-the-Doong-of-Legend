using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeneralTextTyping : MonoBehaviour
{

    private string text;

    public float delay = 0.125f;
    [Header("References")]
    public TMP_Text targetText;
    public bool textExecution = false;  //코루틴 반복 실행 방지

    public static bool IsTyping;  //텍스트 완성 스페이스바 입력과 장면 전환 스페이스바 입력 구분을 위해

    public GameObject textBox;



    // Start is called before the first frame update
    void Start()
    {

        text = targetText.text.ToString();
        targetText.text = " ";

    }

    IEnumerator textPrint()
    {
        int count = 0;
        IsTyping = true;

        float timer = 0f;

        while (count < text.Length)
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                targetText.text += text[count];
                count++;
                timer = 0f;
            }
            yield return null;   //매프레임 실행

        }
        IsTyping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!textExecution)
        {
            textBox.SetActive(true);
            StartCoroutine(textPrint());
            textExecution = true;
        }

        if (IsTyping && Input.GetKeyDown(KeyCode.Space))
        {
            CompleteTextImmediately();
        }
    }

    void CompleteTextImmediately()
    {
        StopAllCoroutines();
        targetText.text = text;
        IsTyping = false;
    }
}
