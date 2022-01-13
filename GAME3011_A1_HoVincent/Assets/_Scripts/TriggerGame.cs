using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.inGame = true;
        }
        Debug.Log(GameManager.Instance.inGame);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.inGame = false;
        }
        Debug.Log(GameManager.Instance.inGame);
    }
}