using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public int buttonNumber; // ��ư�� �Ҵ�� ���ڰ�
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

    /*[������Ʈ Ȱ��ȭ & �巡�׵��]
        1. ��ư�� ������ ��.
        2. ������Ʈ Ȱ��ȭ
        3. ������Ʈ �巡�׾ص��
     */

    public void OnButtonClick()
    {
        CalculateMoney.Instance.CalculateResult(buttonNumber);

        GameObject clone = Instantiate(activeObj, transform.position, Quaternion.identity);
        //activeObj.SetActive(true);

        Debug.Log("���ڰ�: " + buttonNumber);
    }

    public void SetButtonNumber(int number)
    {
        buttonNumber = number;
    }


}
