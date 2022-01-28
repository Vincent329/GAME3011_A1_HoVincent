using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Framework and initialization of states for the Tile Game
/// also handles any visual changes regarding the tiles
/// </summary>
public class TileGameFramework : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;
    
    // not actually saving a grid, need to figure that out... borrow Tic Tac Toe logic?
    [Header("Tile Prefab")]
    [SerializeField] private Tile tilePrefab;
    float tileSize;

    // Store the Tiles in an array
    private Tile[,] tileAreaArray;

    // Keep track of a list of high grade materials based on difficulty
    [SerializeField] private List<Tile> highGradeTiles;

    // Start is called before the first frame update
    void Start()
    {
        highGradeTiles = new List<Tile>();
        tileSize = tilePrefab.GetComponent<RectTransform>().rect.width / 1.35f;
        tileAreaArray = new Tile[width, height];
        InitGrid();

        // bind the function to the delegate in the singleton
        GameManager.Instance.Scan += ScanSurroundingArea;
    }

    void InitGrid()
    {
        for (int i= 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var tile = Instantiate(tilePrefab, /*new Vector3(i * tileSize + transform.position.x, j * tileSize +transform.position.y)*/Vector3.zero, Quaternion.identity);
                tile.name = $"tile {i},{j}";
                //tile.GetComponent<Tile>().SetTileValue((TileType)Random.Range(0, (int)TileType.NUM_OF_TILETYPES));
                tile.transform.SetParent(this.transform);

                // assign the tile in the array
                tileAreaArray[i, j] = tile;
                tileAreaArray[i, j].SetRowColumn(i, j);
            }
        }

        PlaceScoreValues();
    }

    // Called by delegate for scan mode
    void ScanSurroundingArea(int x, int y)
    {
        // first layer of surrounding tiles
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    tileAreaArray[i, j].RevealTileAtLocation(i, j);
                } 
                else
                {
                    Debug.Log("Out of bounds");
                }
            }
        }
        StartCoroutine(forcedDelay(x, y));
        
    }

    IEnumerator forcedDelay(int x, int y)
    {
        Debug.Log("Delay");
        yield return new WaitForSeconds(1.0f);
        // first layer of surrounding tiles
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    tileAreaArray[i, j].ConcealTile();
                }
                else
                {
                    Debug.Log("Out of bounds");
                }
            }
        }
    }
    // this function will be used to delegate score values to the surrrounding tiles
    void PlaceScoreValues()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);

        // set the high grade tile

        foreach(Tile highGradeTile in highGradeTiles)
        {
        }
        AreaCheck(x, y);
    }

    void CheckSurroundingTile()
    {

    }
    void AreaCheck(int x, int y)
    {
        tileAreaArray[x, y].SetTileValue(TileType.HIGH_GRADE);
        highGradeTiles.Add(tileAreaArray[x, y]);

        // first layer of surrounding tiles
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    Debug.Log(tileAreaArray[i, j]);

                    Debug.Log("Possible Tile Found");
                    //if (i != x || j != y)
                    if (tileAreaArray[i, j].GetTileType != TileType.HIGH_GRADE)
                    {
                        tileAreaArray[i, j].SetTileValue(TileType.MID_GRADE);
                        Debug.Log(tileAreaArray[i, j].ScoreValue);
                    }
                    else
                    {
                        Debug.Log("This is a High Grade Tile");
                    }

                }
            }
        }

        //2nd layer of surrounding tiles
        for (int i = x - 2; i <= x + 2; i++)
        {
            for (int j = y - 2; j <= y + 2; j++)
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    Debug.Log(tileAreaArray[i, j]);

                    //if (i != x || j != y)
                    if (tileAreaArray[i, j].GetTileType != TileType.HIGH_GRADE
                        && tileAreaArray[i, j].GetTileType != TileType.MID_GRADE)
                    {
                        tileAreaArray[i, j].SetTileValue(TileType.LOW_GRADE);
                        Debug.Log(tileAreaArray[i, j].ScoreValue);
                    }
                    else
                    {
                        Debug.Log("This is a High or Mid Grade Tile");
                    }

                }
            }
        }
    }

}
