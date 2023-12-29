using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPosManager : MonoBehaviour
{
    [SerializeField] private LineRenderer oilLine;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private float dist;
    private float counter;
    public float lineRenderSpeed = 1;

   
    private void Start()
    {
        oilLine.enabled = false;
        startPos = LineRender.instance.GetStartSpritgePos();
        endPos = LineRender.instance.GetEndSpritgePos();

        //라인의 Position, Width  distance 변수 지정
        oilLine.SetPosition(0, endPos);
        oilLine.SetWidth(0.1f, 0.1f);

        dist = Vector3.Distance(startPos, endPos);
    }
/*    private void oildraw()
    {
        if (endPos != null)
        {
            if(counter<dist)
            {
                counter += .1f / lineRenderSpeed;
                float x = Mathf.Lerp(0, dist, counter);

                Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;
                oilLine.SetPosition(1, pointAlongLine);
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("OilSpot") && LineRender.instance.IsMouseUp)
        {

            oilLine.enabled = true;
            StartCoroutine(OilPumpCo());
            //Debug.Log(oilLine.enabled);
            Debug.Log(collision.CompareTag("OilSpot"));
/*            if (counter < dist)
            {
                counter += .1f / lineRenderSpeed;
                float x = Mathf.Lerp(0, dist, counter);

                Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;
                oilLine.SetPosition(1, pointAlongLine);
            }*/

        }
    }
    private IEnumerator OilPumpCo()
    {
        float x = 0;
        while (true)
        {
            Debug.Log("x : " + x);
            Debug.Log("dist : " + dist);
            counter += .1f / lineRenderSpeed;
            x = Mathf.Lerp(dist, 0, counter);
            Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;
            Debug.Log("pointAlongLine : " + pointAlongLine);
            oilLine.SetPosition(1, pointAlongLine);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
