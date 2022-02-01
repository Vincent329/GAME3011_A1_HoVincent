using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGame : MonoBehaviour
{
    [SerializeField]
    private GameObject TextRender;

    private void Start()
    {
        TextRender.SetActive(false);
        GameManager.Instance.Toggle += ToggleText;
    }

    private void ToggleText()
    {
        TextRender.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.Instance.inGame)
        {
        TextRender.SetActive(true);
        }
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.inGame = true;
        }
        Debug.Log(GameManager.Instance.inGame);
    }

    /// <summary>
    /// Exiting the volume turns off the 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        TextRender.SetActive(false);

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.inGame = false;
            GameManager.Instance.toggleTileGameCanvas(GameManager.Instance.inGame);
        }
        Debug.Log(GameManager.Instance.inGame);
    }
}
