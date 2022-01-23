using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    private TileType tileType;
    [SerializeField]
    private int scoreValue;
    public int ScoreValue => scoreValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTileValue(TileType type)
    {
        tileType = type;
        TileDesignation();
    }

    private void TileDesignation()
    {
        if (tileType == TileType.EMPTY)
        {
            scoreValue = 0;
        }
        else if (tileType == TileType.LOW_GRADE)
        {
            scoreValue = 50;

        }
        else if (tileType == TileType.MID_GRADE)
        {
            scoreValue = 100;

        }
        else if (tileType == TileType.HIGH_GRADE)
        {
            scoreValue = 300;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log(scoreValue);
        // delegate the handling of score here
    }
}
