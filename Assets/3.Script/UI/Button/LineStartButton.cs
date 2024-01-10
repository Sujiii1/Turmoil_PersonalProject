using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineStartButton : MonoBehaviour
{
    private bool startButtonCheck = false;
    //Button Position
    public Vector3 buttonPos { get; private set; }

    private void Update()
    {
        if (startButtonCheck)
        {
            startButtonCheck = false;
        }
            
    }

    public void OnButtonClick()
    {
        startButtonCheck = true;
        buttonPos = transform.position;
        Debug.Log("OnButtonClick");

    }

    

  /*  public bool isSelect = false;

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
    }*/
}
