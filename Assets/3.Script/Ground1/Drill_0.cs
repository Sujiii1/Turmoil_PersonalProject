using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_0 : MonoBehaviour
{
    public GameObject desArea;

    private void Start()
    {

        desArea.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Ground") ||
            collision.transform.CompareTag("Drill")) return;

        desArea.SetActive(true);
        Destroy(this.gameObject, 0.02f);
    }
}
