using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedManager : MonoBehaviour
{
    //LineRender�� Value ���� >0 �̻��� �� Sprite Renderer�� Draw Mode ����
    // ����Ʈ or �迭�� ����
    //��ư ������ �� x�� �ȿ��� ��ġ 

    //EndPos OilSpot�� true -> 

    private GameObject[] pressed;
    private SpriteRenderer spriteRenderer;
    Ground ground;

    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void OilPressed()
    {
        //Pressed�� Draw Mode ���� 
        // Ground�� y�� �޾ƿ���
    }
}
