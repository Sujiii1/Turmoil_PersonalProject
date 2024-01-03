using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedManager : MonoBehaviour
{
    //LineRender의 Value 값이 >0 이상일 때 Sprite Renderer의 Draw Mode 실행
    // 리스트 or 배열로 관리
    //버튼 눌렀을 때 x값 안에서 배치 

    //EndPos OilSpot에 true -> 

    private GameObject[] pressed;
    private SpriteRenderer spriteRenderer;
    Ground ground;

    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void OilPressed()
    {
        //Pressed의 Draw Mode 실행 
        // Ground의 y값 받아오기
    }
}
