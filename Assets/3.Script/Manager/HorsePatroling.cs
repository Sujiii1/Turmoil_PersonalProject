using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePatroling : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim2;
    private Transform currentPoint;
    public float speed;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
        anim2.SetBool("isRunning", true);
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }
/*
    private void Update()
    {
        HorsePos();
    }
*/
    public void HorsePos()
    {
        

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Filp();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Filp();
            currentPoint = pointB.transform;
        }
    }

    private void Filp()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

/*    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }*/
}
