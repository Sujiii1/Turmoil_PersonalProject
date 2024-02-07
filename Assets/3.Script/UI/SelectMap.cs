using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{

    public void LoadSceneString(string a)
    {
        Debug.Log("LoadSceneString" + a);
        SceneManager.LoadScene(a);
    }


    //SceneManager.LoadScene("MainGame_1");

}
