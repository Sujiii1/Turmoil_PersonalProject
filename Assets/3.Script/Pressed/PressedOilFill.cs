using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedOilFill : MonoBehaviour
{
    [SerializeField] private SpriteRenderer oilSprite;
    private float width = 0.13f;
    private float minValue = 0.0f;
    private float maxValue = 1.76f;

    private float nowValue;

    public bool isNowFilling = false;

    private void Awake()
    {
        oilSprite.size = new Vector2(width, minValue);
    }

    private void Update()
    {
        if(isNowFilling)
        {
            SetOilSprite(0.05f);
        }
    }


    public void SetOilSprite(float amount)
    {
        nowValue += amount;
        if(nowValue >= maxValue)
        {
            nowValue = maxValue;
        }
        oilSprite.size = new Vector2(width, nowValue);
    }
}
