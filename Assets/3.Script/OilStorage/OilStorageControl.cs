using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilStorageControl : MonoBehaviour
{
    [SerializeField] private SpriteRenderer oilSaveSprite;
    private float width = 3.37f;
    private float minValue = 0f;
    private float maxValue = 0.94f;

    private float nowValue;
    private bool isNowFilling = false;
    [SerializeField] private float currentOilValue;
    [SerializeField] private PressedOilFill pressedOil;


    private void Awake()
    {
        oilSaveSprite.size = new Vector2(width, minValue);
    }

    public void SetPressedOilFill(PressedOilFill a)
    {
        this.pressedOil = a;
    }

}
