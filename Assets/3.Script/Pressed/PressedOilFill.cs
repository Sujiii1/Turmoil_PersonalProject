using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedOilFill : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    [SerializeField] private SpriteRenderer oilSprite;
    private float width = 0.13f;
    private float minValue = 0.0f;
    private float maxValue = 1.76f;

    private float nowValue;
    public bool isNowFilling = false;

    private float minOilValue = 0;
    private float maxOilValue = 176;

    [SerializeField] private float currentOilValue;
    public float CurrentOilValue => currentOilValue;

    


    private void Awake()
    {
        oilSprite.size = new Vector2(width, minValue);
    }

    private void Update()
    {
        if(isNowFilling)
        {
            SetOilSprite(0.0005f);
        }
    }

    public void GiveOilToHorse()
    {
        nowValue = minValue;
        isNowFilling = true;
        boxCollider2D.enabled = false;
        gameObject.layer = 8;
    }

    public void SetOilSprite(float amount)
    {
        nowValue += amount;
        
        if (nowValue >= maxValue)
        {
            nowValue = maxValue;
            isNowFilling = false;
            boxCollider2D.enabled = true;
            gameObject.layer = 0;
        }

        currentOilValue = (nowValue * 100);
        oilSprite.size = new Vector2(width, nowValue);
    }
}
