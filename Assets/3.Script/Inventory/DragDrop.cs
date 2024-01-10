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

    Vector3 SpaceObjPos;
    Vector3 mousePos;

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
                /*            this.gameObject.transform.position
                            = new Vector3(this.gameObject.transform.localPosition.x, SpaceObjPosY, -1f) ;*/
                this.gameObject.transform.position
                            = new Vector3(mousePos.x, SpaceObjPosY, -1f);
            }
        }
    }

    private void OnMouseDown()
    {
        isBeingHeld = false;
        //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);

        if (isInLine)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*            this.gameObject.transform.position
                        = new Vector3(this.gameObject.transform.localPosition.x, SpaceObjPosY, -1f) ;*/
            this.gameObject.transform.position
                        = new Vector3(mousePos.x, SpaceObjPosY, -1f);
        }


        if (Input.GetMouseButtonDown(0))
        {
            //spriteRenderer.color = new Color(1f, 1f, 1f, .5f);

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
        //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);

        if (isInLine)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*            this.gameObject.transform.position
                        = new Vector3(this.gameObject.transform.localPosition.x, SpaceObjPosY, -1f) ;*/
            this.gameObject.transform.position
                        = new Vector3(mousePos.x, SpaceObjPosY, -1f);
        }
       // else this.gameObject.transform.position = LoadPos; // Original Position
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpaceObj"))
        {
            isInLine = true;
            //SpaceObjPos = collision.transform.position;
            SpaceObjPosY = collision.transform.position.y;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SpaceObj"))
        {
            isInLine = false;
        }
    }*/
}

