using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public bool inGame;
    public static GameManager Instance
    {
        get => instance;
    }

    [SerializeField]
    private GameObject tileGameCanvas;
    [SerializeField]
    private GameObject promptText;

    public UnityAction m_ToggleCanvas;

    private void Awake()
    {
        if (instance != null )
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        inGame = false;
        tileGameCanvas.SetActive(false);
        Debug.Log(tileGameCanvas.activeInHierarchy);
    }

    //private void Update()
    //{
    //    tileGameCanvas.SetActive(inGame);
    //}

    public void toggleTileGameCanvas(bool toggle)
    {
        tileGameCanvas.SetActive(toggle);

    }


}
