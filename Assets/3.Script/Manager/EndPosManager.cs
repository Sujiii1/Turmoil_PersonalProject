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
    Coroutine oil_wait_co = null;

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

    /*    private void Drill_Move_OnArriveDrill(object sender, EventArgs e)
        {
            OilPumb();
        }

        private void OilPumb()
        {
            StartCoroutine(OilPumpCo_Co());
        }*/




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (LineRender.instance.IsMouseUp && collision.CompareTag("OilSpot"))
        {
            StartCoroutine(OilPumpCo_Co());
        }

        if (collision.CompareTag("Finish"))
        {
            if (oil_wait_co == null) {
                oil_wait_co = collision.GetComponent<EndPosManager>().StartCoroutine(OilPumpCo_Co());
            }
            
        }
    }

    public IEnumerator OilPumpCo_Co()
    {
        Debug.Log($"OilPumpCo_Co");
        yield return new WaitForSeconds(8f);
        oil_wait_co = null;
        

        oilLine.enabled = true;
        StartCoroutine(OilPumpCo());
        
    }

    private IEnumerator OilPumpCo()
    {
        float x = 0;

        //Oil Value 가 min<0 일 때,
        while (true)
        {
            counter += .2f / lineRenderSpeed;            //Oil 올라오는 속도
            x = Mathf.Lerp(dist, 0, counter);
            Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;

/*            List<Vector3> posList = LineRender.instance.oilPosList;
            posList.Reverse();
            Debug.Log(posList.Count);
            oilLine.positionCount = posList.Count;
            oilLine.SetPositions(posList.ToArray());*/
            oilLine.SetPosition(1, pointAlongLine);
            SetEdgeColider();
            yield return new WaitForSeconds(0.2f);


            if (Mathf.Abs(x) < 0.05f)
            {
                yield break;
            }
        }
    }

    
   
    public void SetEdgeColider()        //LineRender Collider
    {
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

    //StartPos에 endCollider가 닿았을 때 Pressed의 Slider 작동
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Plus"))
        {
            Vector2 size = spriteRenderer.size;
            Vector2 newSize = new Vector2(size.x, newheight);
            spriteRenderer.size = newSize;

            newheight = Mathf.Sin(Time.time);
        }
    }
}
