using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoGame : MonoBehaviour
{
    private Button button;


    private void Awake()
    {
        button = GetComponent<Button>();

        GetMapButton_1();
        //GetMapButton_2();
        //GetMapButton_3();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("3. SelectMapScene");
        }
    }
    public void GetMapButton_1()
    {
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("MainGame_1");
        }
    }   
   /* public void GetMapButton_2()
    {
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("MainGame_2");
        }
    }
    public void GetMapButton_3()
    {
        if(Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("MainGame_3");
        }
    }*/
}
