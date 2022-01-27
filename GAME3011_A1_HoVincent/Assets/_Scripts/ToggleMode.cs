using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleMode : MonoBehaviour
{
    Button buttonComponent;
    [SerializeField]
    bool test;

    // Start is called before the first frame update
    void Start()
    {
        test = false;
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(SwitchToggle);
    }
    
    private void SwitchToggle()
    {
        Debug.Log("Switch");

        GameManager.Instance.scanMode = !GameManager.Instance.scanMode;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
            GameManager.Instance.scanMode ? "Extract Mode" : "Search Mode";
        test = !test;

       
    }
}
