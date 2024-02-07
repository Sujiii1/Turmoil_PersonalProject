using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOil : MonoBehaviour
{
    [SerializeField] private GameObject[] oil;

    void Update()
    {
        if (LineRender.instance.isDrag)
        {
            // �����
            for(int i=0; i < oil.Length; i++)
            {
                // if (oil[i] �갡 �߰ߵ� ��Ȳ�̸� �ȼ����, ���� �ȹ߰ߵ� �ָ� �����)
                oil[i].SetActive(false);
            }
        }
        else
        {
            // �����ش�
            for (int i = 0; i < oil.Length; i++)
            {
                oil[i].SetActive(true);
            }
        }
    }
}
