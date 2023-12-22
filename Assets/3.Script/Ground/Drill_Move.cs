using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill_Move : MonoBehaviour
{
    public GameObject desArea;
    public bool isWork = true;
    [SerializeField] private bool isCol = false;

    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;

    private Vector2 direction;

    private void Start()
    {
        //desArea.SetActive(false);
        startPos = Inputmanager.instance.GetStartSpritgePos();
        endPos = Inputmanager.instance.GetEndSpritgePos();
        direction = (endPos - startPos).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        //Quaternion rotation = Quaternion.LookRotation(angleAxis);
        transform.rotation = angleAxis;

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
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPos, 0.5f * Time.deltaTime);
                //if (gameObject.transform.position == endPos) Destroy(gameObject);
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
