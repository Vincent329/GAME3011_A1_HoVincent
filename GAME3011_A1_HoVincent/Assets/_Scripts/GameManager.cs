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

    [SerializeField] private int score;
    [SerializeField] private int goldOre;
    [SerializeField] private int redOre;
    [SerializeField] private int coatOre;
    [SerializeField] private int stoneOre;

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
    private GameObject WinText;

    [Header("Vincium Amounts")]
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject coat;
    [SerializeField] private GameObject stone;

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
        WinText.GetComponent<TextMeshProUGUI>().text = "";
        ChangeText("Click a Tile to dig up Vincium.  Click the bottom left button to toggle scan and extract modes. Mine 2000 Vincium to win!");

        score       = 0;
        goldOre     = 0;
        redOre      = 0;
        coatOre     = 0;
        stoneOre    = 0;

        gold.GetComponent<TextMeshProUGUI>().text = ": " + goldOre;
        red.GetComponent<TextMeshProUGUI>().text = ": " + redOre;
        coat.GetComponent<TextMeshProUGUI>().text = ": " + coatOre;
        stone.GetComponent<TextMeshProUGUI>().text = ": " + stoneOre;

        digLimit    = 3;
        scanLimit   = 6;
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
            ChangeText("Final Vincium Count: " + score + ". \n You can press E to close the menu, or click Restart to reset the game");


            WinText.GetComponent<TextMeshProUGUI>().text = score > 2000 ? "You Win!" : "You Lose!";
        }
    }

    public void UpdateRunningResource(TileType type)
    {
        if (type == TileType.MINIMAL_GRADE)
        {
            stoneOre++;
            stone.GetComponent<TextMeshProUGUI>().text = ": " + stoneOre;
        }
        else if (type == TileType.LOW_GRADE)
        {
            coatOre++;
            coat.GetComponent<TextMeshProUGUI>().text = ": " + coatOre;

        }
        else if (type == TileType.MID_GRADE)
        {
            redOre++;
            red.GetComponent<TextMeshProUGUI>().text = ": " + redOre;

        }
        else if (type == TileType.HIGH_GRADE)
        {
            goldOre++;
            gold.GetComponent<TextMeshProUGUI>().text = ": " + goldOre;

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
        goldOre = 0;
        redOre = 0;
        coatOre = 0;
        stoneOre = 0;

        digLimit = 3;
        scanLimit = 6;

        gold.GetComponent<TextMeshProUGUI>().text = ": " + goldOre;
        red.GetComponent<TextMeshProUGUI>().text = ": " + redOre;
        coat.GetComponent<TextMeshProUGUI>().text = ": " + coatOre;
        stone.GetComponent<TextMeshProUGUI>().text = ": " + stoneOre;

        WinText.GetComponent<TextMeshProUGUI>().text = "";
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
