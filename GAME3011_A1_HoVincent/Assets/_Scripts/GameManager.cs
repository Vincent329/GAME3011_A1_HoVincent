using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        tileGameCanvas.SetActive(inGame);
    }


}
