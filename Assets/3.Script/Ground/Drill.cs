using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    BoxCollider2D drillCol;

    float x;
    float y;
    public Vector3 drillPos;
    public Quaternion drillRot;

    //Drill End Point -> Inputmanager- endSprite ÀÇ Position °ª

    private void OnEnable()
    {
        drillCol = GetComponent<BoxCollider2D>();
        drillPos = transform.position;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Ground"))
        {
            if(col.TryGetComponent(out Ground g))
            {
                StartCoroutine(g.makeHole_co(drillCol));
            }
            if(col.TryGetComponent(out LineRender i))
            {
                //drillPos = i.endSprite.transform.position;
                drillRot = i.endSprite.transform.rotation;
                return;
            }
        }
    }
}
