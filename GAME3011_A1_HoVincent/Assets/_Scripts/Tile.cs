using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int row, column;


    [SerializeField]
    private TileType tileType;
    public TileType GetTileType => tileType;
    [SerializeField]
    private Image imageComp;
    [SerializeField]
    private int scoreValue;
    public int ScoreValue => scoreValue;

    [SerializeField]
    private Sprite MinLoad, LowLoad, MidLoad, HighLoad;
    // Start is called before the first frame update
    void OnEnable()
    {
        imageComp = GetComponent<Image>();
        MinLoad = Resources.Load<Sprite>("Stone");
        LowLoad = Resources.Load<Sprite>("Coat");
        MidLoad = Resources.Load<Sprite>("Redstone");
        HighLoad = Resources.Load<Sprite>("Gold");
        TileDesignation();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTileValue(TileType type)
    {
        tileType = type;
        Debug.Log(tileType);
        TileDesignation();
    }

    private void TileDesignation()
    {
        if (tileType == TileType.MINIMAL_GRADE)
        {
            scoreValue = 0;
          //  imageComp.sprite = MinLoad;
          //  Debug.Log("Access");
        }
        else if (tileType == TileType.LOW_GRADE)
        {
            scoreValue = 50;
           // imageComp.sprite = LowLoad;

        }
        else if (tileType == TileType.MID_GRADE)
        {
            scoreValue = 100;
            //imageComp.sprite = MidLoad;

        }
        else if (tileType == TileType.HIGH_GRADE)
        {
            scoreValue = 300;
            imageComp.sprite = HighLoad;
        }
    }

    private void RevealTile()
    {
        if (tileType == TileType.MINIMAL_GRADE)
        {
            imageComp.sprite = MinLoad;
        }
        else if (tileType == TileType.LOW_GRADE)
        {
            imageComp.sprite = LowLoad;

        }
        else if (tileType == TileType.MID_GRADE)
        {
            imageComp.sprite = MidLoad;

        }
        else if (tileType == TileType.HIGH_GRADE)
        {
            imageComp.sprite = HighLoad;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log(scoreValue);
        RevealTile();
        // delegate the handling of score here
    }
}
