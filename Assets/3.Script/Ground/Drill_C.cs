using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_C : MonoBehaviour
{
    BoxCollider2D c;
    private void OnEnable()
    {
        c = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Ground"))
        {
            if(col.TryGetComponent(out Ground_0 g))
            {
                StartCoroutine(g.makeHole_co(c));
            }
        }
    }
}
