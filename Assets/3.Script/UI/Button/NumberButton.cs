using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public int buttonNumber; // 버튼에 할당된 숫자값
    private Button button;
    [SerializeField] GameObject activeObj;
   // [SerializeField] Animator dowserquest;

    private void Awake()
    {
       // dowserquest = GetComponent<Animator>();
    }

    private void Start()
    {
        //activeObj.SetActive(false);
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button not found.");
        }
    }

    public void OnButtonClick()
    {
        if (!button.interactable) return;

        button.interactable = false;
        CalculateMoney.Instance.CalculateResult(buttonNumber);

        GameObject clone = Instantiate(activeObj, transform.position, Quaternion.identity);

        StartCoroutine(ButtonDelay());
        
    }
    
    private IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(0.05f);
        button.interactable = true;
    }

    public void SetButtonNumber(int number)
    {
        buttonNumber = number;
    }
}
