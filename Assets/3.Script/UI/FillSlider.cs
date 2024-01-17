using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSlider : MonoBehaviour
{
    public int maxValue;
    public Image fill;
 // public float reduceSpeed;

    private float currentValue;

    public bool isNowPressing;

    private void Start()
    {
        currentValue = maxValue;
        fill.fillAmount = 1;
    }

    private void Update()
    {
        if(isNowPressing)
        {
            Deduct(0.03f);
        }
    }

    public void Deduct(float i)
    {
        //현재 Value 감소
        currentValue -= i;

        if (currentValue < 0)
            currentValue = 0;

        fill.fillAmount = (float)currentValue / maxValue;
    }

}
