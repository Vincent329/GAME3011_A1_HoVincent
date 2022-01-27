using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Singleton that keeps track of UI elements and Game Statistics
/// </summary>
public class GameManager : MonoBehaviour
{
    // set up singleton
    private static GameManager instance;

    public bool inGame;
    public bool scanMode;

    [SerializeField]
    private int score;

    public int digLimit;
    public int scanLimit;

    public static GameManager Instance
    {
        get => instance;
    }

    [SerializeField]
    private GameObject tileGameCanvas;
    [SerializeField]
    private GameObject promptText;

    // Delegates
    public delegate void ScanArea(int row, int column);
    public event ScanArea Scan;

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
        // Initialize variables
        inGame = false;
        scanMode = false;
        tileGameCanvas.SetActive(false);
        Debug.Log(tileGameCanvas.activeInHierarchy);

        score = 0;
        digLimit = 3;
        scanLimit = 6;
    }

    public void ScanTiles(int x, int y)
    {
        Scan(x, y);
    }

    public void toggleTileGameCanvas(bool toggle)
    {
        tileGameCanvas.SetActive(toggle);
    }

    public void togglePrompt(bool toggle)
    {
        promptText.SetActive(toggle);
    }

    public void ScanMode()
    {
        scanMode = true;
    }

    public void ExtractMode()
    {
        scanMode = false;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void EasyToggle()
    {

    }

    public void MediumToggle()
    {

    }

    public void HardToggle()
    {

    }


}
