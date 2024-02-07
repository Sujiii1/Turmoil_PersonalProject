using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactoryControl : MonoBehaviour
{
    [SerializeField] private float factoryMoney;
    [SerializeField] private TextMeshPro textMeshPro;

    [SerializeField] private FactoryControl otherFactory;
    public bool isMoneyUp;

    private void Awake()
    {
        factoryMoney = 2000;
    }

    private void Start()
    {
        textMeshPro.text = string.Format("${0:#,##}", factoryMoney);
    }

    private void Update()
    {
        if (otherFactory.isMoneyUp)
        {
            DownMoney();
        }
        else
        {
            SetMoney();
        }
    }

    private void SetMoney()
    {
        isMoneyUp = true;
        factoryMoney += 10 * Time.deltaTime;
        textMeshPro.text = string.Format("${0:#,##}", factoryMoney);

        if(factoryMoney >= 3000)
        {
            isMoneyUp = false;
            factoryMoney = 3000;
        }
    }

    private void DownMoney()
    {
        isMoneyUp = false;
        factoryMoney -= 10 * Time.deltaTime;
        textMeshPro.text = string.Format("${0:#,##}", factoryMoney);

        if (factoryMoney <= 1000)
        {
            isMoneyUp = true;
            factoryMoney = 1000;
        }
    }

    public float GetMoney()
    {
        return factoryMoney;
    }
}
