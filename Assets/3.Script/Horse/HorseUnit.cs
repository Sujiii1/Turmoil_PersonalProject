using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseUnit : MonoBehaviour
{
    [SerializeField] private bool isFillOil = false;
    [SerializeField] GameObject horseOil;

    [SerializeField] private int filloil;

    public int myIndex;


    private void Start()
    {
        GameManager.Instance.horseUnitList.Add(this);
        myIndex = GameManager.Instance.horseUnitList.Count;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Pressed") && !isFillOil)
        {
            isFillOil = true;
            horseOil.SetActive(isFillOil);
            collision.gameObject.GetComponent<PressedOilFill>().GiveOilToHorse();
            filloil = (int)collision.gameObject.GetComponent<PressedOilFill>().CurrentOilValue;
            gameObject.layer = 9;
            Physics2D.IgnoreLayerCollision(9, 9, true);
            Physics2D.IgnoreLayerCollision(9, 8, true);
            Physics2D.IgnoreLayerCollision(9, 0, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Factory") && isFillOil)
        {
            isFillOil = false;
            horseOil.SetActive(isFillOil);
            CalculateMoney.Instance.CalculateAddResult((int)collision.gameObject.GetComponent<FactoryControl>().GetMoney());
            filloil = 0;

            gameObject.layer = 7;
            Physics2D.IgnoreLayerCollision(7, 7, true);
            Physics2D.IgnoreLayerCollision(7, 8, true);
            Physics2D.IgnoreLayerCollision(7, 0, false);
        }
    }

    public void FillOil(int a)
    {
        filloil += a;
    }
}
