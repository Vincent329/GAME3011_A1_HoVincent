using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Framework and initialization of states for the Tile Game
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

    // Start is called before the first frame update
    void Start()
    {
        tileSize = tilePrefab.GetComponent<RectTransform>().rect.width / 2;
        tileAreaArray = new Tile[width, height];
        InitGrid();
    }

    void InitGrid()
    {
        for (int i= 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var tile = Instantiate(tilePrefab, new Vector3(i * tileSize + transform.position.x, j * tileSize +transform.position.y), Quaternion.identity);
                tile.name = $"tile {i},{j}";
                //tile.GetComponent<Tile>().SetTileValue((TileType)Random.Range(0, (int)TileType.NUM_OF_TILETYPES));
                tile.transform.SetParent(this.transform);

                // place the tile in the array
                tileAreaArray[i, j] = tile;
            }
        }

        PlaceScoreValues();
    }

    // this function will be used to delegate score values to the surrrounding tiles
    void PlaceScoreValues()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);

        tileAreaArray[x, y].SetTileValue(TileType.HIGH_GRADE);
        //Debug.Log(testTile.ScoreValue);

        // first layer of surrounding tiles
        for (int i = x-1; i  <= x+1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < width && j >= 0 && j < height)
                {
                    Debug.Log(tileAreaArray[i, j]);

                    Debug.Log("Possible Tile Found");
                    if (i != x || j != y)
                    {
                        tileAreaArray[i, j].SetTileValue(TileType.MID_GRADE);
                        Debug.Log(tileAreaArray[i, j].ScoreValue);
                    }  
                    
                }
            }
        }
    }


}
