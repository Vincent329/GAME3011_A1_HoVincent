using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

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
        tileGameCanvas.SetActive(false);
        Debug.Log(tileGameCanvas.activeInHierarchy);
    }

}
