using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGame : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;

    [Header("Tile Prefab")]
    [SerializeField] private Tile tilePrefab;
    float tileSize;
    // Start is called before the first frame update
    void Start()
    {
        tileSize = tilePrefab.GetComponent<RectTransform>().rect.width;
        Debug.Log(tileSize);
        InitGrid();
    }

    void InitGrid()
    {
        for (int i= 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var tile = Instantiate(tilePrefab, new Vector3(i * tileSize, j * tileSize ), Quaternion.identity);
                tile.name = $"tile {i},{j}";
                tile.transform.SetParent(this.transform);
            }
        }
    }
}
