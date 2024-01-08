using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSystem : MonoBehaviour
{
    public List<Button> buttons;
    public List<int> buttonNumbers = new List<int> { 100, 100, 100, 350, 250, 150 };

    private void Start()
    {
        if (buttons.Count != buttonNumbers.Count)
        {
            Debug.LogError("버튼과 숫자값이 일치하지 않습니다.");
            return;
        }

        AssignNumbersToButtons();
    }

    private void AssignNumbersToButtons()
    {
        // 숫자를 각 버튼에 할당
        for (int i = 0; i < buttons.Count; i++)
        {
            int buttonNumber = buttonNumbers[i];
            buttons[i].GetComponent<NumberButton>().SetButtonNumber(buttonNumber);
        }
    }
}
