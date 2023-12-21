using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssentialObject : MonoBehaviour
{
    //Button Position
    public float x;
    public float y;
    public Vector3 buttonPos;

    public void startDrawButton()
    {
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
