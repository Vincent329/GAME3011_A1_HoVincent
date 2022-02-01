using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    Button buttonComponent;

    // Start is called before the first frame update
    void Start()
    {
        buttonComponent = GetComponent<Button>();
        buttonComponent.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        GameManager.Instance.ResetTheGame();
    }
}
