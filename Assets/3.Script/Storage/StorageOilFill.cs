using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageOilFill : MonoBehaviour
{
    [SerializeField] private SpriteRenderer oilSaveSprite;
    private float width = 3.37f;
    private float minValue = 0f;
    private float maxValue = 0.94f;

    private float nowValue;
    private bool isNowFilling = false;
    [SerializeField] private float currentOilValue;

    private void Awake()
    {
        oilSaveSprite.size = new Vector2(width, minValue);
    }

    public void SetOilSprite(float amount)
    {
        nowValue += amount;

        if(nowValue >= maxValue)
        {
            nowValue = maxValue;
            isNowFilling = false;
            gameObject.layer = 0;
        }
       // currentOilValue = (nowValue * 100);
        oilSaveSprite.size = new Vector2(width, nowValue);
    }
}
