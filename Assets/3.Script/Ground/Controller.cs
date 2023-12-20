using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 MousePosition; //Drill 로 바꾸기
    public LayerMask whatisGround;
  public GameObject desObj;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Collider2D overColider2d = Physics2D.OverlapBox(MousePosition, new Vector2(5f,5f), 45f ,whatisGround);
            Collider2D overColider2d = Physics2D.OverlapCircle(MousePosition,0.01f, whatisGround);
            if(overColider2d != null)
            {
                overColider2d.transform.GetComponent<Ground>().MakeDot(MousePosition);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            MousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Instantiate(desObj, MousePosition, desObj.transform.rotation);
        }
    }
    
}
