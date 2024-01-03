using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineStartButton : MonoBehaviour
{
    //Button Position
    public float x;
    public float y;
    public Vector3 buttonPos;

    public bool isSelect = false;

    public void set_Select()
    {
        isSelect = false;
    }

    public void startDrawButton()
    {
        isSelect = true;
        Debug.Log("isSelect : " + isSelect);
        buttonPos = transform.position;

        Debug.Log(gameObject.transform.position);
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("pressed"))
        {
            
        }
    }*/
}
