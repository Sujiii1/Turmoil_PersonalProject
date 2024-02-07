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
            Deduct(0.05f);
        }
    }


/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Drill"))
        {
            Debug.Log("Endpos" + collision.name);
            isNowPressing = true;
        }
    }*/

    /* public void Add(int i)
     {
         //현재 Value 증가
         currentValue += i;

         if (currentValue > maxValue)
             currentValue = maxValue;

         fill.fillAmount = (float)currentValue / maxValue;

     }*/
    public void Deduct(float i)
    {
        //현재 Value 감소
        currentValue -= i;

        if (currentValue < 0)
            currentValue = 0;

        fill.fillAmount = (float)currentValue / maxValue;
    }

}
