using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputmanager : MonoBehaviour
{
    [SerializeField] private LineRenderer trajectoryLine;
    [SerializeField] private GameObject endSpritePrefebs;
    public GameObject endSprite;

    public static Inputmanager instance = null;

    private Vector3 startPos;
    private Vector3 endPos;
    public GameObject drills;

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
        showTrajectoryLine();
    }

    #region[LineRenderer Draw]
    private void showTrajectoryLine()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

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
            trajectoryLine.enabled = false;
            if(endSprite != null)
            {
                endPos = endSprite.transform.position;
                Destroy(endSprite);
                Instantiate(drills, startPos, drills.transform.rotation);
                Debug.Log($"{endSprite.transform.position}");
            }
        }
    }
    #endregion

    public Vector3 GetStartSpritgePos()
    {
        return startPos;
    }

    public Vector3 GetEndSpritgePos()
    {
        return endPos;
    }

}
