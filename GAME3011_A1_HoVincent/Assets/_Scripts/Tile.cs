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
    private bool diggable;

    public bool Diggable => diggable;


    [SerializeField]
    private Sprite Covered, MinLoad, LowLoad, MidLoad, HighLoad;



    // Start is called before the first frame update
    void OnEnable()
    {
        imageComp = GetComponent<Image>();
        Covered = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        MinLoad = Resources.Load<Sprite>("Stone");
        LowLoad = Resources.Load<Sprite>("Coat");
        MidLoad = Resources.Load<Sprite>("Redstone");
        HighLoad = Resources.Load<Sprite>("Gold");
        TileDesignation();
        diggable = true;
    }

    public void SetTileValue(TileType type)
    {
        StopAllCoroutines();
        tileType = type;
        Debug.Log(tileType);
        TileDesignation();
    }

    public void SetRowColumn(int x, int y)
    {
        row = x;
        column = y;
    }

    private void TileDesignation()
    {
        if (tileType == TileType.MINIMAL_GRADE)
        {
            scoreValue = 125;
          //  imageComp.sprite = MinLoad;
          //  Debug.Log("Access");
        }
        else if (tileType == TileType.LOW_GRADE)
        {
            scoreValue = 250;
           // imageComp.sprite = LowLoad;

        }
        else if (tileType == TileType.MID_GRADE)
        {
            scoreValue = 500;
            //imageComp.sprite = MidLoad;

        }
        else if (tileType == TileType.HIGH_GRADE)
        {
            scoreValue = 1000;
            //imageComp.sprite = HighLoad;
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

    public void RevealTileAtLocation(int x, int y)
    {
        if (x == row && y == column)
        {
            RevealTile();
        }
    }

    public void ConcealTile()
    {
        imageComp.sprite = Covered;
    }
    IEnumerator depleteTile()
    {
        yield return new WaitForSeconds(1.0f);
        tileType = TileType.MINIMAL_GRADE;
        imageComp.sprite = MinLoad;
    }

    /// <summary>
    /// Testing the degrading of a tile
    /// </summary>
    public void DegradeTile()
    {
        if (tileType > (int)TileType.MINIMAL_GRADE)
        {
            Debug.Log("Degrade Tile");
            tileType--;
        }
        TileDesignation();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (GameManager.Instance.scanMode == false && diggable == true 
            && GameManager.Instance.digLimit > 0)
        {
            RevealTile();
            GameManager.Instance.AddScore(scoreValue);

            // decrement the extraction value
            GameManager.Instance.UpdateDigIcons();
            GameManager.Instance.UpdateRunningResource(tileType);
            StartCoroutine(depleteTile());

            // Degrade surrounding area
            GameManager.Instance.DegradeTiles(row, column);
            diggable = false;
        } 
            else if (GameManager.Instance.scanMode == true && GameManager.Instance.scanLimit > 0)
        {
            // figure out scan mode functionality here
            // decrement scan counter in game manager instance
            GameManager.Instance.ScanTiles(row, column);
        }
    }
}
