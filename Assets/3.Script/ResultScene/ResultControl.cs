using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultControl : MonoBehaviour
{
    [SerializeField] private Text earningsText;
    [SerializeField] private Text spendingsText;
    [SerializeField] private Text lossText;

    private void Start()
    {
        //string.Format("${0:#,##}", factoryMoney);
        if(CalculateMoney.Instance.earnings <= 0)
        {
            earningsText.text = "$0,000";
        }
        else
        {
            earningsText.text = string.Format("${0:#,##}", CalculateMoney.Instance.earnings);
        }

        if (CalculateMoney.Instance.spendings == 0)
        {
            spendingsText.text = "$0,000";
        }
        else
        {
            spendingsText.text = string.Format("${0:#,##}", CalculateMoney.Instance.spendings);
        }
        
        
        lossText.text = string.Format("${0:#,##}", CalculateMoney.Instance.lossMoney);
    }
}
