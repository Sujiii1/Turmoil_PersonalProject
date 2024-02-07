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
            // 숨긴다
            for(int i=0; i < oil.Length; i++)
            {
                // if (oil[i] 얘가 발견된 상황이면 안숨기고, 아직 안발견된 애만 숨기기)
                oil[i].SetActive(false);
            }
        }
        else
        {
            // 보여준다
            for (int i = 0; i < oil.Length; i++)
            {
                oil[i].SetActive(true);
            }
        }
    }
}
