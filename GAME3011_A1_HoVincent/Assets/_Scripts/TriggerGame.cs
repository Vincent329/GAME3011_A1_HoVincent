using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGame : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
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
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.inGame = false;
            GameManager.Instance.toggleTileGameCanvas(GameManager.Instance.inGame);
        }
        Debug.Log(GameManager.Instance.inGame);
    }
}
