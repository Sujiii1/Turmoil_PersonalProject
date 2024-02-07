using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Move : MonoBehaviour
{
    public static EventHandler OnArriveDrill;
    [SerializeField] private bool isCheckOil = false;

    public GameObject desArea;
    public bool isWork = true;
    private bool isWorkDone = false;
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
        if(!isWorkDone)
        {
            PipeDraw();
        }
        
    }

    private void PipeDraw()
    {
        //Pipe Draw

        LineRender.instance.GetLineRenderer().SetPosition(0, transform.position);
        pipeLine.SetPosition(1, transform.position);
        if (Vector3.Distance(transform.position, endPos) <= 0.1f)
        {
            if (LineRender.instance.Drill != null)
            {
                Debug.Log("도착!");
/*                if (isCheckOil)
                {
                    Debug.Log("오일 발견");
                    OnArriveDrill?.Invoke(this, EventArgs.Empty);
                    isCheckOil = false;
                }*/

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                LineRender.instance.Drill.GetComponent<BoxCollider2D>().enabled = true;
                LineRender.instance.Drill.transform.GetChild(0).transform.GetComponent<BoxCollider2D>().enabled = true;
                LineRender.instance.Drill = null;
                isWorkDone = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OilSpot"))
        {
            isCheckOil = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("OilSpot"))
        {
            isCheckOil = false;
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
