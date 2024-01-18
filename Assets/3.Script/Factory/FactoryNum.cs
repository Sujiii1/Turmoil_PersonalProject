using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryNum : MonoBehaviour
{
    [SerializeField] private Text numText;
    [SerializeField] private int numInt = 0;

    [SerializeField] private bool isRight;



    public void BtnUp()
    {
        numInt += 1;
        numText.text = numInt.ToString();

        for(int i = 0; i < numInt; i++)
        {
            //���� �� ����⸦ ã�� �� ���� HorsePatroling�� A�������� �ٲٱ� (�ش� Factory�� A��� B��������)
            //���߿� null ����ó�� 

            if (isRight)
            {
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().ChangeAPoint(FindMostFarPressed());
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().SetHavePoint(false);
            }
            else
            {
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().ChangeBPoint(FindMostFarPressed());
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().SetHavePoint(false);
            }
        }
    }


    public void BtnDown()
    {
        for (int i = 0; i < numInt; i++)
        {
            if(i == numInt-1)
            {
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().SetHavePoint(true);
                continue;
            }

            //���� �� ����⸦ ã�� �� ���� HorsePatroling�� A�������� �ٲٱ� (�ش� Factory�� A��� B��������)
            //���߿� null ����ó�� 
            if (isRight)
            {
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().ChangeAPoint(FindMostFarPressed());
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().SetHavePoint(false);
            }
            else
            {
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().ChangeBPoint(FindMostFarPressed());
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().SetHavePoint(false);
            }
        }


        numInt -= 1;
        numText.text = numInt.ToString();

        for (int i = 0; i < numInt; i++)
        {
            //���� �� ����⸦ ã�� �� ���� HorsePatroling�� A�������� �ٲٱ� (�ش� Factory�� A��� B��������)
            //���߿� null ����ó�� 
            if (isRight)
            {
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().ChangeAPoint(FindMostFarPressed());
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().SetHavePoint(false);
            }
            else
            {
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().ChangeBPoint(FindMostFarPressed());
                GameManager.Instance.horseUnitList[i].gameObject.GetComponent<Patroling>().SetHavePoint(false);
            }
        }
    }

    private Vector3 FindMostFarPressed()
    {
        GameObject[] transforms = GameObject.FindGameObjectsWithTag("Pressed");
        GameObject target = transforms[0];
        float distance = Vector2.Distance(target.transform.position, gameObject.transform.position);
        


        foreach(GameObject pressed in transforms)
        {
            float nowDistance = Vector2.Distance(pressed.transform.position, gameObject.transform.position);
            if(nowDistance > distance)
            {
                distance = nowDistance;
                target = pressed;
            }
        }
        Debug.Log(target.name);
        return target.transform.position;
        
    }
}
