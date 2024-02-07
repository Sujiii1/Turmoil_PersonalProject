using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    private Vector3 BasepointA;
    private Vector3 BasepointB;

    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim2;
   // [SerializeField] private Animator anim3;
    [SerializeField] private Animator dowserAnimator;
    [SerializeField] private Vector3 currentPoint;
    public float speed;

    [SerializeField] private bool isDowser;
    [SerializeField] private bool isHorse;

    [SerializeField] private LayerMask OilSpotLayer;
    private float timer = 30f;
    private bool isFindOil = false;

    private bool isNoHavePoint = false;
    private bool isRight = true;

    private void Awake()
    {
        pointA = new Vector3(-7f, -1.2f, -1f);
        pointB = new Vector3(8f, -1.2f, -1f);

        BasepointA = pointA;
        BasepointB = pointB;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB;
        if(isHorse)
        {
            anim.SetBool("isRunning", true);
            anim2.SetBool("isRunning", true);
           // anim.SetBool("isQuest", true);
        }
        Physics2D.IgnoreLayerCollision(7, 8, true);
        Physics2D.IgnoreLayerCollision(7, 7, true);
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
        if (isFindOil || isNoHavePoint)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if(isDowser)
        {
            if(dowserAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dowser_benddown") && dowserAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
            {
                rb.velocity = Vector2.zero;
                return;
            }
            if (timer <= 0)
            {
                DetectOilSpot();
            }
        }

        if (currentPoint == pointB)
        {
            isRight = true;
            rb.velocity = new Vector2(speed, 0);
        }
        else if (currentPoint == pointA)
        {
            isRight = false;
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint) <= 1.0f && currentPoint == pointB)
        {
            if(isRight)
            {
                Filp();
                currentPoint = pointA;
            }
        }
        else if (Vector2.Distance(transform.position, BasepointB) <= 1.0f)
        {
            if (isRight)
            {
                Filp();
                currentPoint = pointA;
            }
        }

        if (Vector2.Distance(transform.position, currentPoint) <= 1.0f && currentPoint == pointA)
        {
            if (!isRight)
            {
                Filp();
                currentPoint = pointB;
            }
        }
        else if (Vector2.Distance(transform.position, BasepointA) <= 1.0f)
        {
            if (!isRight)
            {
                Filp();
                currentPoint = pointB;
            }
        }
    }

    private void DetectOilSpot()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(2, 2), 0f, -transform.up, 100f, OilSpotLayer);
        if (hit)
        {
            dowserAnimator.SetTrigger("FindOil");
            hit.collider.gameObject.layer = 0;

            isFindOil = true;
            Destroy(gameObject, 7f);
        }


    }
    private void Filp()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }



    public void ChangeAPoint(Vector3 newAPoint)
    {
        Debug.Log(pointA);
        pointA = newAPoint;

        if(!isRight)
        {
            currentPoint = pointA;
        }
        Debug.Log(pointA);
    }

    public void ChangeBPoint(Vector3 newBPoint)
    {
        Debug.Log(pointB);
        pointB = newBPoint;

        if(isRight)
        {
            currentPoint = pointB;
        }
        Debug.Log(pointB);
    }

    public void SetHavePoint(bool value)
    {
        if (value)
        {
            pointA = new Vector3(-7f, -1.2f, -1f);
            pointB = new Vector3(8f, -1.2f, -1f);
            isNoHavePoint = value;

            if (isRight)
            {
                currentPoint = pointB;
            }
            else
            {
                currentPoint = pointA;
            }
        }
        else
        {
            isNoHavePoint = value;
        }



    }

    /*    private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
            Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        }*/
}
