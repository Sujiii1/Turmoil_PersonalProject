using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    //[SerializeField] GameObject DragObj;
    [SerializeField] SpriteRenderer spriteRenderer;
    public Vector3 LoadPos;
    float startPosX;
    float startPosY;
    bool isBeingHeld = false;
    public bool isInLine;
    float SpaceObjPosY;
    Vector3 SpaceObjPos;
    Vector3 mousePos;

    private void Start()
    {
        LoadPos = this.transform.position;
    }

    private void Update()
    {
        if(isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position =
                new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {
        if(CompareTag("Item"))
        {
            if (Input.GetMouseButtonDown(0))
            {

                spriteRenderer.color = new Color(1f, 1f, 1f, .5f);

                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                startPosX = mousePos.x - this.transform.position.x;
                startPosY = mousePos.y - this.transform.position.y;

                isBeingHeld = true;
            }
        }
    }

    private void OnMouseUp()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        isBeingHeld = false;

        if (isInLine)
        {
            /*this.gameObject.transform.position
                            = new Vector3(this.gameObject.transform.localPosition.x, SpaceObjPosY, -1f);*/

            this.gameObject.transform.position
            = new Vector3(mousePos.x, SpaceObjPosY, -1f);

            // 쏙 들어가는거
            //transform.position = SpaceObjPos;
        }
        else this.gameObject.transform.position = LoadPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
        if(collision.CompareTag("SpaceObj"))
        {
            isInLine = false;
        }
    }
}

