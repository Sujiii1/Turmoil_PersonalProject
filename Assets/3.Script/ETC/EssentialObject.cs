using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssentialObject : MonoBehaviour
{
    SpriteRenderer sprite;

    public void startDrawButton()
    {
        Debug.Log(gameObject.transform.position);
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("pressed"))
        {
            
        }
    }*/
}
