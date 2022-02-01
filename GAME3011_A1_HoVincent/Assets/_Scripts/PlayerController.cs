using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement variables")]
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private Vector3 playerVelocity;
    private Rigidbody rb;

    

    private bool inRange; // activate input for the minigame while inside the hitbox
    public bool InRange
    {
        get => inRange;
        set
        {
            inRange = value;
        }
    }

    [Header ("Player Input System")]
    

    private InputAction moveAction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //moveAction = playerInput.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
    }

    //private void HandlePlayerInputs()
    //{
    //    Vector2 moveValue = moveAction.ReadValue<Vector2>();
    //    playerVelocity = new Vector3(moveValue.x, 0, moveValue.y);
    //}

    public void OnMove(InputValue value)
    {
        Vector2 moveValue = value.Get<Vector2>();
        playerVelocity = new Vector3(moveValue.x, 0, moveValue.y);
    }

    public void OnActivate(InputValue value)
    {
        if (GameManager.Instance.inGame == true)
        {
            GameManager.Instance.TextToggle();
            GameManager.Instance.toggleTileGameCanvas(true);
        } else
        {
            Debug.Log("Not in the Zone");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerVelocity * playerSpeed * Time.deltaTime);
    }

}
