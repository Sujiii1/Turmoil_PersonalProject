
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour      //Dig the Ground 
{
    BoxCollider2D drillCol;
    Ground ground;

    float x;
    float y;
    public Vector3 drillPos;
    public Quaternion drillRot;

    //Drill End Point -> Inputmanager- endSprite 의 Position 값

    private void OnEnable()
    {
        drillCol = GetComponent<BoxCollider2D>();
        drillPos = transform.position;
    }

    private void Start()
    {
        ground = GetComponent<Ground>();
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 100f);

        if (col.CompareTag("Ground"))
        {
            //그라운드 임을 인식 -> StartPos를 눌렀을 때 

            if(drillCol != null)
            {
                if (col.TryGetComponent(out Ground g))
                {
                    StartCoroutine(g.makeHole_co(drillCol));
                }
            }
           
            if(col.TryGetComponent(out LineRender i))
            {
                drillRot = i.endSprite.transform.rotation;
                return;
            }
        }
    }
}
