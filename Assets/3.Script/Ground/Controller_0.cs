using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_0 : MonoBehaviour
{
    Vector3 MousPosition;
    public LayerMask Ground;

    public GameObject drills;

    private void Update()
    {
  /*      if(Input.GetMouseButton(0))
        {
            MousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D overCollider2d = Physics2D.OverlapCircle(MousPosition, 0.01f, Ground);
            overCollider2d.gameObject.GetComponent<Ground_0>().makeDot(MousPosition);
        }*/
        if(Input.GetMouseButtonDown(1))
        {
            MousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MousPosition.z = 0f;
            Instantiate(drills, MousPosition, drills.transform.rotation);
        }
    }
}
