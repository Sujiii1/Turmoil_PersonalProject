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
    [SerializeField] private bool isOilStorage;
    public bool isOverPresssed = false;
    [SerializeField] private bool isFinish = false;

    public bool isBeingHeld = true;
    public bool isInLine = true;
    [SerializeField] private float SpaceObjPosY;

    Patroling horsePatroling;

    Vector3 mousePos;

    Vector3 oilStoragePos;

    [SerializeField] private OilStorageControl oilStorage;

    private void Awake()
    {
        horsePatroling = GetComponent<Patroling>();
    }
    private void Start()
    {
        if(isOilStorage)
        {
            TryGetComponent(out oilStorage);
        }

        LoadPos = this.transform.position;
        isBeingHeld = true;
        isInLine = true;
    }


    private void Update()
    {
        ObjPos();
        
    }

    public void ObjPos()
    {
        if (isBeingHeld && !isFinish)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position =
                new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }


        if(Input.GetMouseButtonDown(0) && isBeingHeld && !isOilStorage && !isFinish)
        {
            isBeingHeld = false;
            isFinish = true;
            if (isInLine)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.gameObject.transform.position
                            = new Vector3(mousePos.x, SpaceObjPosY, -1f);
               
            }
        }

        else if(Input.GetMouseButtonDown(0) && isBeingHeld && isOilStorage && isOverPresssed && !isFinish)
        {
            isBeingHeld = false;
            isFinish = true;
            if (isInLine)
            {
                this.gameObject.transform.position
                            = new Vector3(oilStoragePos.x + 1.3f, SpaceObjPosY, -1f);
            }
            isOverPresssed = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Pressed") && isOilStorage)
        {
            isOverPresssed = true;
            oilStoragePos = collision.transform.position;
            oilStorage.SetPressedOilFill(collision.GetComponent<PressedOilFill>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pressed") && isOilStorage)
        {
            isOverPresssed = false;
        }
    }


    private void OnMouseDown()
    {
        isBeingHeld = false;

        if (isInLine && !isFinish &&!isOilStorage)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            this.gameObject.transform.position
                        = new Vector3(mousePos.x, SpaceObjPosY, -1f);
        }

        if (Input.GetMouseButtonDown(0) && !isFinish && !isOilStorage)
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
        if (isInLine && !isFinish && !isOilStorage)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().simulated = true;
            }
            
            this.gameObject.transform.position
                        = new Vector3(mousePos.x, SpaceObjPosY, -1f);
        }
        else if(isInLine && !isFinish && isOilStorage && isOverPresssed)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().simulated = true;
            }

            this.gameObject.transform.position
                        = new Vector3(mousePos.x, SpaceObjPosY, -1f);
        }
    }
}

