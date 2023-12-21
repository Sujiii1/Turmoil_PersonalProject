using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_0 : MonoBehaviour
{
    public GameObject desArea;
    public bool isWork = true;
    [SerializeField] private bool isCol = false;
    private void Start()
    {
        //desArea.SetActive(false);

        StartCoroutine(drill_co());

    }

    //private void Update()
    //{
    //    gameObject.transform.position += new Vector3(0, -1f, 0) *Time.deltaTime;
    //}
    public IEnumerator drill_co()
    {
        while(true)
        {
            if(isWork)
            {
                gameObject.transform.position += new Vector3(0, -1f, 0) * Time.deltaTime*0.5f;
            }
            yield return null;
        }
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!collision.transform.CompareTag("Ground") ||
    //        collision.transform.CompareTag("Drill")) return;
    //
    //    desArea.SetActive(true);
    //    //Destroy(this.gameObject, 0.02f);
    //}
/*
    private IEnumerator isWork_co()
    {
        isCol = true;
        isWork = true;
        desArea.SetActive(isWork);
        yield return new WaitForSeconds(0.02f);
        isWork = false;
        desArea.SetActive(isWork);
        yield return new WaitForSeconds(1f);
        isCol = false;
    }*/
}
