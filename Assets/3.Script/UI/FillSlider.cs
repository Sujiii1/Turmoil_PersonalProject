using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSlider : MonoBehaviour
{
    public int maxValue;
    public Image fill;

    public int currentValue;

    private void Start()
    {
        currentValue = maxValue;
        fill.fillAmount = 1;
    }

    public void Add(int i)
    {
        //���� Value ����
        currentValue += i;

        if (currentValue > maxValue)
            currentValue = maxValue;

        fill.fillAmount = (float)currentValue / maxValue;

    }
    public void Deduct(int i)
    {
        //���� Value ����
        currentValue -= i;

        if (currentValue < maxValue)
            currentValue = 0;

        fill.fillAmount = (float)currentValue / maxValue;

    }

}
