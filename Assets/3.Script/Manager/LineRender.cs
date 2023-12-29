using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    [SerializeField] private LineRenderer trajectoryLine;   //점선 라인
    [SerializeField] private GameObject endSpritePrefebs;
    public GameObject endSprite;

    public static LineRender instance = null;

    public  Vector3 startPos;
    public Vector3 endPos;
    public GameObject drills;

    public GameObject Drill;

    public bool IsMouseUp = false;
    public bool isDrag = false;

    private void Awake()
    {
        #region [싱글톤]
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        #endregion
    }

    private void Start()
    {
        trajectoryLine.enabled = false;
        
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            isDrag = true;

            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 100f);
            //Debug.Log(hit.transform.name);
            if(hit.transform.CompareTag("Endpos")|| hit.transform.CompareTag("Plus"))
            {
                trajectoryLine.enabled = true;
                trajectoryLine.positionCount = 2;
                trajectoryLine.SetPosition(0, new Vector3(hit.transform.transform.position.x, hit.transform.transform.position.y, -1f));
                startPos = new Vector3(hit.transform.position.x, hit.transform.position.y, -1f);

              
            }
            //showTrajectoryLine();

        }
        if (Input.GetMouseButton(0))
        {
            trajectoryLine.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -1f));
            if (endSprite == null)
            {
                endSprite = Instantiate(endSpritePrefebs, new Vector3(mousePos.x, mousePos.y, -1f), Quaternion.identity);
            }
            else
            {
                endSprite.transform.position = new Vector3(mousePos.x, mousePos.y, -1f);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;

            if (endSprite != null)
            {
                endPos = endSprite.transform.position;
                Instantiate(endSprite, endPos, Quaternion.identity);         //GameObject Clone =  //endSprit 유지 
                Destroy(endSprite);
                Drill=Instantiate(drills, startPos, drills.transform.rotation);
                IsMouseUp = true;
                //Debug.Log($"{endSprite.transform.position}");
            }
        }
    }

    #region[LineRenderer Draw]

    #region Past

    public void showTrajectoryLine()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            trajectoryLine.enabled = true;
            trajectoryLine.positionCount = 2;

            // 드릴 시작점의 포지션 넣기


            trajectoryLine.SetPosition(0, new Vector3(FindObjectOfType<EssentialObject>().transform.position.x, FindObjectOfType<EssentialObject>().transform.position.y, -1f));
            startPos = new Vector3(FindObjectOfType<EssentialObject>().transform.position.x, FindObjectOfType<EssentialObject>().transform.position.y, -1f);
            //trajectoryLine.SetPosition(0, FindObjectOfType<EssentialObject>().transform.position);

            trajectoryLine.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -1));

            //끝점의 Sprite 
            if(endSprite== null)
            {
                endSprite = Instantiate(endSpritePrefebs, new Vector3(mousePos.x, mousePos.y, -1), Quaternion.identity);
                
            }
            else
            {
                endSprite.transform.position = new Vector3(mousePos.x, mousePos.y, -1);
            }
        } 
        else
        {
            //trajectoryLine.enabled = false;
            if(endSprite != null)
            {
                endPos = endSprite.transform.position;
                Instantiate(endSprite, endPos, Quaternion.identity);         //GameObject Clone =  //endSprit 유지 
                Destroy(endSprite);
                
                Instantiate(drills, startPos, drills.transform.rotation);
                 
                //Debug.Log($"{endSprite.transform.position}");
            }
        }
    }
    #endregion




    #endregion

    public Vector3 GetStartSpritgePos()
    {
        return startPos;
    }

    public Vector3 GetEndSpritgePos()
    {
        return endPos;
    }

    public LineRenderer GetLineRenderer()
    {
        return trajectoryLine;
    }

}
