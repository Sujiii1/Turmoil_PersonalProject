using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //===================================

    public List<HorseUnit> horseUnitList;


    private void Awake()
    {
        #region [ΩÃ±€≈Ê]
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        #endregion

        horseUnitList = new List<HorseUnit>();

    }
}
