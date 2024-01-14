using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseUnit : MonoBehaviour
{
    [SerializeField] private bool isFillOil = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Pressed") && !isFillOil)
        {
            isFillOil = true;
            collision.gameObject.GetComponent<PressedOilFill>().GiveOilToHorse();
        }
    }
}
