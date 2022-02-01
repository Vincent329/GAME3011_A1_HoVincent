using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

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

    [Header("In Game Elements")]
    [SerializeField]
    private GameObject tileGameCanvas;
    [SerializeField]
    private GameObject promptText;

    [SerializeField]
    private List<GameObject> DigPrompts;
    [SerializeField]
    private List<GameObject> ScanPrompts;


    // Delegates
    public delegate void ScanArea(int row, int column);
    public event ScanArea Scan;

    public delegate void DegradeArea(int row, int column);
    public event DegradeArea Degrade;

    public delegate void ToggleText();
    public event ToggleText Toggle;
    
    public delegate void ResetGame();
    public event ResetGame Reset;

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
        //scanMode = false;
        tileGameCanvas.SetActive(false);
        Debug.Log(tileGameCanvas.activeInHierarchy);

        ChangeText("Click a Tile to dig up Vincium.  Click the bottom left button to switch between scan and extract modes");

        score = 0;
        digLimit = 3;
        scanLimit = 6;
    }

    public void UpdateDigIcons()
    {
        digLimit--;
        DigPrompts[digLimit].SetActive(false);
        if (digLimit <= 0)
        {
            scanLimit = 0;
            foreach (GameObject scans in ScanPrompts)
            {
                scans.SetActive(false);
            }
            ChangeText("Final Vincium Count: " + score + ". \n You can press E to close the menu, or click Restart to rest the game");
        }
    }

    public void ScanTiles(int x, int y)
    {
        Scan(x, y);
        scanLimit--;
        ScanPrompts[scanLimit].SetActive(false);
    }

    public void DegradeTiles(int x, int y)
    {
        Degrade(x, y);
    }

    public void TextToggle()
    {
        Toggle(); 
    }

    public void toggleTileGameCanvas(bool toggle)
    {
        tileGameCanvas.SetActive(toggle);
    }

    public void togglePrompt(bool toggle)
    {
        promptText.SetActive(toggle);
    }
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        ChangeText("Vincium Obtained: " + score);
    }

    public void ChangeText(string text)
    {
        promptText.GetComponent<TextMeshProUGUI>().text = text;
    }

    public void ResetTheGame()
    {
        score = 0;
        digLimit = 3;
        scanLimit = 6;
        ChangeText("Vincium Obtained: " + score);
        foreach (GameObject digs in DigPrompts)
        {
            digs.SetActive(true);
        }
        foreach (GameObject scans in ScanPrompts)
        {
            scans.SetActive(true);
        }
        Reset();
    }

}
