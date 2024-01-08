using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    private int buttonNumber; // ��ư�� �Ҵ�� ���ڰ�
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button not found.");
        }
    }

    private void OnButtonClick()
    {
        Debug.Log("���ڰ�: " + buttonNumber);
    }

    public void SetButtonNumber(int number)
    {
        buttonNumber = number;
    }
}
