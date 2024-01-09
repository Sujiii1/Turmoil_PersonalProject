using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateMoney : MonoBehaviour
{
    public static CalculateMoney Instance = null;

    public Text[] digitTexts; // �ټ� �ڸ� ���ڸ� ��Ÿ�� �ؽ�Ʈ ������Ʈ �迭

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
            Debug.Log($"{i} �ε��� : {fiveArray[i]}");
        }

        DisplayDigits();
    }

    /*    private void GenerateRandomNumberArray()
        {
            System.Random random = new System.Random();

            for (int i = 0; i < 5; i++)
            {
                fiveDigitArray[i] = random.Next(10); // 0���� 9������ ������ �� �Ҵ�
            }
        }
    */

    /*
        1. ���ڰ� �Ҵ�� ��ư ����
        2. baseResult ���� �����Ǿ� ����� ���
    */
/*    private void CalculNum()
    {
        if (numberButton != null)
        {
            // 1. ���ڰ� �Ҵ�� ��ư�� ����
            int buttonNumber = numberButton.fixedButtonNumber;

            // 2. baseResult���� �����Ǿ� ����� ���
            int currentResult = fiveArray[5] - buttonNumber;
            Debug.Log("���� �����: " + currentResult);

        }
    }*/


    // �� �ڸ����� �ؽ�Ʈ ������Ʈ�� ���
    private void DisplayDigits()
    {
        for (int i = 0; i < 5; i++)
        {
            digitTexts[i].text = fiveArray[i].ToString();
        }
    }
}
