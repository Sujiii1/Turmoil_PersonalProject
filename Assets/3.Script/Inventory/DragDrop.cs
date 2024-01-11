using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] GameObject DragObj;
    //[SerializeField] SpriteRenderer spriteRenderer;
    public Vector3 LoadPos;
    float startPosX;
    float startPosY;

    [SerializeField] private bool isBeingHeld = true;
    public bool isInLine = true;
    float SpaceObjPosY;

    HorsePatroling horsePatroling;

    Vector3 mousePos;

    private void Awake()
    {
        horsePatroling = GetComponent<HorsePatroling>();
    }
    private void Start()
    {
        LoadPos = this.transform.position;
        isBeingHeld = true;
        isInLine = true;
    }


    private void Update()
    {
        ObjPos();
        
    }

    private void ObjPos()
    {
        if (isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position =
                new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }

        if(Input.GetMouseButtonDown(0) && isBeingHeld)
        {
            isBeingHeld = false;
            if (isInLine)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.gameObject.transform.position
                            = new Vector3(mousePos.x, SpaceObjPosY, -1f);
            }
        }
    }

    private void OnMouseDown()
    {
        isBeingHeld = false;

        if (isInLine)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position
                        = new Vector3(mousePos.x, SpaceObjPosY, -1f);
        }

        if (Input.GetMouseButtonDown(0))
        {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;

        if (isInLine)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position
                        = new Vector3(mousePos.x, SpaceObjPosY, -1f);
        }
        horsePatroling.HorsePos();
    }
}

