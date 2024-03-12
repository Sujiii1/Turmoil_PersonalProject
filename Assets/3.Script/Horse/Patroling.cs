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

    private bool isPressedFilled = false; // Pressed 오브젝트에 기름이 채워졌는지 여부


    private bool isPressedLayerIgnored = false;


    public bool isSettingUnit = false;
    public bool isSettingUnit_RightFactory = false;
    public bool isSettingUnit_LeftFactory = false;

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
        if (isHorse)
        {
            anim.SetBool("isRunning", true);
            anim2.SetBool("isRunning", true);
        }
        Physics2D.IgnoreLayerCollision(7, 8, true);
        Physics2D.IgnoreLayerCollision(7, 7, true);
        Physics2D.IgnoreLayerCollision(7, 9, true);
    }

    private void Update()
    {
        if (isFindOil || isNoHavePoint ) return;
        timer -= Time.deltaTime;

        if (isDowser && timer <= 0)
        {
            DetectOilSpot();
        }

        //UpdatePressedLayerCollision();
    }


    private void FixedUpdate()
    {
        if (isDowser) HorsePos();

        if (!isSettingUnit) return;
        HorsePos();
    }

    public void HorsePos()
    {
        if (isFindOil || isNoHavePoint)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (isDowser)
        {
            if (dowserAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dowser_benddown") && dowserAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
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
            if (isRight)
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
            Destroy(gameObject, 5f);
        }
    }

    private void Filp()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void UpdatePressedLayerCollision()
    {
        if (isDowser && !isPressedFilled && !isPressedLayerIgnored)
        {
            // Pressed 레이어와의 충돌을 무시
            Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Pressed"), true);
            isPressedLayerIgnored = true;
        }
        else if ((!isDowser || isPressedFilled) && isPressedLayerIgnored)
        {
            // Pressed 레이어와의 충돌을 다시 활성화
            Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Pressed"), false);
            isPressedLayerIgnored = false;
        }
    }


    public void ChangeAPoint(Vector3 newAPoint)
    {
        pointA = newAPoint;

        if (!isRight)
        {
            currentPoint = pointA;
        }
    }

    public void ChangeBPoint(Vector3 newBPoint)
    {
        pointB = newBPoint;

        if (isRight)
        {
            currentPoint = pointB;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pressed"))
        {
            if (!isFindOil && isDowser && isPressedFilled) // Pressed 오브젝트에 기름이 채워져 있을 때만 충돌 처리
            {
                DetectOilSpot();
            }
        }
    }

    public void SetPressedFilled(bool filled)
    {
        isPressedFilled = filled;
    }


}
