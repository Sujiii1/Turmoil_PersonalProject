using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EdgeCollider2D))]
public class EndPosManager : MonoBehaviour
{
    [SerializeField] private LineRenderer oilLine;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private EndPosManager startEPM;
    [SerializeField] private Vector3 endPos;

    private float dist;
    private float counter;
    public float lineRenderSpeed = 1;

    //Colider
    EdgeCollider2D edgeCollider2D;
    SpriteRenderer spriteRenderer;

    float newheight;
    bool is_oil_co = false;
    bool isCanPressed = false;


    private void Start()
    {
        //Drill_Move.OnArriveDrill += Drill_Move_OnArriveDrill;
        oilLine.enabled = false;
        startPos = LineRender.instance.GetStartSpritgePos();
        endPos = LineRender.instance.GetEndSpritgePos();

        //라인의 Position, Width  distance 변수 지정
        oilLine.SetPosition(0, endPos);
        oilLine.SetWidth(0.1f, 0.1f);

        dist = Vector3.Distance(startPos, endPos);

        //Colider
        edgeCollider2D = this.GetComponent<EdgeCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log("isCanPressed = " + isCanPressed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);

        if (LineRender.instance.IsMouseUp && collision.CompareTag("OilSpot"))
        {
            StartCoroutine(OilPumpCo_Co(collision.GetComponent<FillSlider>()));
            
            LineRender.instance.IsMouseUp = false;
        }

        if (collision.CompareTag("Finish"))
        {
            edgeCollider2D.enabled = false;
            EndPosManager epm = collision.GetComponent<EndPosManager>();
            if (!epm.is_oil_co) 
            {
                epm.StartCoroutine(epm.OilPumpCo_Co(collision.GetComponent<FillSlider>()));
            }
        }

        if (collision.CompareTag("Plus") && isCanPressed)
        {
            Debug.Log("오일 뽑자");
            collision.transform.parent.GetComponent<PressedOilFill>().isNowFilling = true;
        }

    }

    public IEnumerator OilPumpCo_Co(FillSlider a)
    {
        is_oil_co = true;
        isCanPressed = true;
        edgeCollider2D.enabled = false;

        Debug.Log($"OilPumpCo_Co" + gameObject.name);
        yield return new WaitForSeconds(8f);
        if(a != null)
        {
            a.isNowPressing = true;
        }

        oilLine.enabled = true;
        StartCoroutine(OilPumpCo());
    }

    private IEnumerator OilPumpCo()
    {
        float x = 0;
        while (true)
        {
            //원래 0.2f 속도였음 근데 오중근왈 좀 너무 느림 0.5는 해야함
            counter += 0.6f / lineRenderSpeed;            //Oil 올라오는 속도
            x = Mathf.Lerp(dist, 0, counter);
            if (Mathf.Abs(x) < 0.05f)
            {
                SetEdgeColider();
                is_oil_co = false;
                yield break;
            }
            Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;
            oilLine.SetPosition(1, pointAlongLine);
            
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void SetEdgeColider()        //LineRender Collider
    {
        edgeCollider2D.enabled = true;
        List<Vector2> edges = new List<Vector2>();

        float original_x = oilLine.GetPosition(0).x;            //기본 위치값 0
        float original_y = oilLine.GetPosition(0).y;

        for (int i = 0; i < oilLine.positionCount; i++)
        {
            Vector3 oilLinePoint = oilLine.GetPosition(i);
            edges.Add(new Vector2(oilLinePoint.x - original_x, oilLinePoint.y - original_y));   
        }
        edgeCollider2D.SetPoints(edges);
    }
}
