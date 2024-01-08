using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateMoney : MonoBehaviour
{
    public Text[] digitTexts; // �ټ� �ڸ� ���ڸ� ��Ÿ�� �ؽ�Ʈ ������Ʈ �迭

    //private int[] fiveDigitArray = new int[5];
    private int[] fiveArray = { 0, 2, 0, 0, 0 };

    NumberButton numberButton;
    ButtonSystem buttonSystem;

    private void Awake()
    {
        numberButton = GetComponent<NumberButton>();
        buttonSystem = GetComponent<ButtonSystem>();
    }

    private void Start()
    {
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
    private void CalculNum()
    {
        if (numberButton != null)
        {
            // 1. ���ڰ� �Ҵ�� ��ư�� ����
            int buttonNumber = numberButton.fixedButtonNumber;

            // 2. baseResult���� �����Ǿ� ����� ���
            int currentResult = fiveArray[5] - buttonNumber;
            Debug.Log("���� �����: " + currentResult);

            // ���⿡�� �ʿ��� �۾��� �����ϸ� �˴ϴ�.
        }
    }


    // �� �ڸ����� �ؽ�Ʈ ������Ʈ�� ���
    private void DisplayDigits()
    {
        for (int i = 0; i < 5; i++)
        {
            digitTexts[i].text = fiveArray[i].ToString();
        }
    }
}
