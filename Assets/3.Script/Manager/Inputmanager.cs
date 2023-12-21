using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputmanager : MonoBehaviour
{
    [SerializeField] private LineRenderer trajectoryLine;
    EssentialObject game;


    private void Start()
    {
        trajectoryLine.enabled = false;
    }

    private void Update()
    {
        showTrajectoryLine();
    }
    private void showTrajectoryLine()
    {
        if(Input.GetMouseButton(0))
        {
            

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
            
            trajectoryLine.enabled = true;
            trajectoryLine.positionCount = 2;

            // �帱 �������� ������ �ֱ�
            /*      if(TryGetComponent(out EssentialObject a))          //��ũ��Ʈ ���� �ϱ�
                  {
                      game = a;

                  }*/
            trajectoryLine.SetPosition(0, FindObjectOfType<EssentialObject>().transform.position);

            trajectoryLine.SetPosition(1, mousePos);
        }


    }

}
