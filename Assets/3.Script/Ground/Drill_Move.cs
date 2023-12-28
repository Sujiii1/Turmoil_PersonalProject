using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Move : MonoBehaviour
{
    public GameObject desArea;
    public bool isWork = true;
    [SerializeField] private bool isCol = false;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private Vector2 direction;

    //Pipe
    [SerializeField] private LineRenderer pipeLine;
    private float dist;
    private float counter;
    public float lineDrawSpeed = 0;

    private void Start()
    {
        startPos = LineRender.instance.GetStartSpritgePos();
        endPos = LineRender.instance.GetEndSpritgePos();
        
        direction = (endPos - startPos).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = angleAxis;

        StartCoroutine(drill_co());

        //Pipe Pos,Wid
        pipeLine.SetPosition(0, startPos);
        pipeLine.SetWidth(0.15f, 0.15f);

        dist = Vector3.Distance(startPos, endPos);
    }

    private void Update()
    {
        LineRender.instance.GetLineRenderer().SetPosition(0, transform.position);

        //Pipe Draw
        /*if (counter < dist)
        {
            counter += .1f / lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;
            pipeLine.SetPosition(1, pointAlongLine);
        }*/
        pipeLine.SetPosition(1, transform.position);
        if(Vector3.Distance(transform.position,endPos)<=0.1f)
        {
            if (LineRender.instance.Drill != null)
            {
                LineRender.instance.Drill.GetComponent<BoxCollider2D>().enabled = false;        
                LineRender.instance.Drill.transform.GetChild(0).transform.GetComponent<BoxCollider2D>().enabled = false;    //endPoint-> startPoint °¡ µÇ¸é true
                LineRender.instance.Drill = null;
            }
        }
    }
    public IEnumerator drill_co()
    {
        while(true)
        {
            if(isWork)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPos, 0.5f * Time.deltaTime);
            }
            yield return null;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!collision.transform.CompareTag("Ground") ||
    //        collision.transform.CompareTag("Drill")) return;
    //
    //    desArea.SetActive(true);
    //    //Destroy(this.gameObject, 0.02f);
    //}
/*
    private IEnumerator isWork_co()
    {
        isCol = true;
        isWork = true;
        desArea.SetActive(isWork);
        yield return new WaitForSeconds(0.02f);
        isWork = false;
        desArea.SetActive(isWork);
        yield return new WaitForSeconds(1f);
        isCol = false;
    }*/
}
