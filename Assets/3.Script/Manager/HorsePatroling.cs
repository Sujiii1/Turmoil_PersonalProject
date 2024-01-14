using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePatroling : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim2;
    [SerializeField] private Animator anim3;
    [SerializeField] private Animator dowserAnimator;
    [SerializeField] private Transform currentPoint;
    public float speed;

    [SerializeField] private bool isDowser;
    [SerializeField] private bool isHorse;

    [SerializeField] private LayerMask OilSpotLayer;
    private float timer = 3f;
    private bool isFindOil = false;

    private void Awake()
    {
        pointA = GameObject.FindGameObjectWithTag("APoint");
        pointB = GameObject.FindGameObjectWithTag("BPoint");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        if(isHorse)
        {
            anim.SetBool("isRunning", true);
            anim2.SetBool("isRunning", true);
            anim.SetBool("isQuest", true);
        }
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }

    private void Update()
    {
        if (isFindOil) return;
        timer -= Time.deltaTime;
    }


    private void FixedUpdate()
    {
        HorsePos();
    }

    public void HorsePos()
    {
        if (isFindOil)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if(isDowser)
        {
            if(dowserAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dowser_benddown") && dowserAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
            {
                rb.velocity = Vector2.zero;
                //감지하는 메서드 넣기
                return;
            }
            if (timer <= 0)
            {
                DetectOilSpot();
            }
        }

        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if (currentPoint == pointA.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) <= 1.0f && currentPoint == pointB.transform)
        {
            Filp();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) <= 1.0f && currentPoint == pointA.transform)
        {
            Filp();
            currentPoint = pointB.transform;
        }
    }

    private void DetectOilSpot()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(2, 2), 0f, -transform.up, 100f, OilSpotLayer);
        if (hit)
        {
            dowserAnimator.SetTrigger("FindOil");
            hit.collider.gameObject.layer = 0;
/*            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);*/
            isFindOil = true;
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
