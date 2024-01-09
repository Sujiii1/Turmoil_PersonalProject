using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateMoney : MonoBehaviour
{
    public static CalculateMoney Instance = null;

    public Text[] digitTexts; // 다섯 자리 숫자를 나타낼 텍스트 오브젝트 배열

    //private int[] fiveDigitArray = new int[5];
    private int[] fiveArray = { 0, 2, 0, 0, 0 };

    NumberButton numberButton;
    ButtonSystem buttonSystem;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }


        numberButton = GetComponent<NumberButton>();
        buttonSystem = GetComponent<ButtonSystem>();
    }

    private void Start()
    {
        DisplayDigits();
    }

    public void CalculateResult(int num)
    {
        int currentResult = (fiveArray[0] * 10000) + (fiveArray[1] * 1000) + (fiveArray[2] * 100) + (fiveArray[3] * 10) + fiveArray[4];

        Debug.Log("Debug.Log(currentResult); : " + currentResult);

        int nowResult = currentResult - num;

        fiveArray[0] = nowResult / 10000;
        fiveArray[1] = (nowResult % 10000) / 1000;
        fiveArray[2] = (nowResult % 1000) / 100 ;
        fiveArray[3] = (nowResult % 100) / 10;
        fiveArray[4] = nowResult % 10;

        Debug.Log(nowResult);

        for(int i = 0; i < fiveArray.Length; i++)
        {
            Debug.Log($"{i} 인덱스 : {fiveArray[i]}");
        }

        DisplayDigits();
    }

    /*    private void GenerateRandomNumberArray()
        {
            System.Random random = new System.Random();

            for (int i = 0; i < 5; i++)
            {
                fiveDigitArray[i] = random.Next(10); // 0부터 9까지의 랜덤한 값 할당
            }
        }
    */

    /*
        1. 숫자가 할당된 버튼 누름
        2. baseResult 에서 뺄셈되어 결과값 출력
    */
/*    private void CalculNum()
    {
        if (numberButton != null)
        {
            // 1. 숫자가 할당된 버튼을 누름
            int buttonNumber = numberButton.fixedButtonNumber;

            // 2. baseResult에서 뺄셈되어 결과값 출력
            int currentResult = fiveArray[5] - buttonNumber;
            Debug.Log("현재 결과값: " + currentResult);

        }
    }*/


    // 각 자릿수를 텍스트 오브젝트에 출력
    private void DisplayDigits()
    {
        for (int i = 0; i < 5; i++)
        {
            digitTexts[i].text = fiveArray[i].ToString();
        }
    }
}
