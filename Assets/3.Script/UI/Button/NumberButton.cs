using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public int buttonNumber; // 버튼에 할당된 숫자값
    private Button button;
    [SerializeField] GameObject activeObj;

/*    public static NumberButton Instance = null;

    private void Awake()
    {
        #region [SingleTone] 
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }*/

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

    /*[오브젝트 활성화 & 드래그드랍]
        1. 버튼을 눌렀을 때.
        2. 오브젝트 활성화
        3. 오브젝트 드래그앤드랍
     */

    public void OnButtonClick()
    {
        CalculateMoney.Instance.CalculateResult(buttonNumber);

        GameObject clone = Instantiate(activeObj, transform.position, Quaternion.identity);
        //activeObj.SetActive(true);

        Debug.Log("숫자값: " + buttonNumber);
    }

    public void SetButtonNumber(int number)
    {
        buttonNumber = number;
    }


}
