using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGame : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;
    
    // not actually saving a grid, need to figure that out... borrow Tic Tac Toe logic?
    [Header("Tile Prefab")]
    [SerializeField] private Tile tilePrefab;
    float tileSize;
    // Start is called before the first frame update
    void Start()
    {
        tileSize = tilePrefab.GetComponent<RectTransform>().rect.width / 2;
        Debug.Log(tileSize);
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
                tile.GetComponent<Tile>().SetTileValue((TileType)Random.Range(0, (int)TileType.NUM_OF_TILETYPES));
                tile.transform.SetParent(this.transform);
            }
        }
    }
}
