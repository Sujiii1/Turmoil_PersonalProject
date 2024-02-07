using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    [SerializeField] private GameObject questionUI;
    private bool isButtonDown = false;

    Button button;

    public void YesLoad(string a)
    {
        PopUp();
        StartCoroutine(Delay(a));

        
    }

    public void PopUp()
    {
        isButtonDown = true;
        questionUI.SetActive(true);
    }

/*    public void Yes(string a)
    {
        
    }*/

    private IEnumerator Delay(string a)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(a);
    }
    public void NO()
    {
        questionUI.SetActive(false);
    }    

}
