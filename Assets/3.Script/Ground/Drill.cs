using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public GameObject destroyObj;

    private void Start()
    {
        destroyObj.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Ground")||
            collision.transform.CompareTag("Drill")) return;

        destroyObj.SetActive(true);
        Destroy(this.gameObject, 0.02f);
        
    }
}
