using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    private Vector2 playerMovimentInput;

    [Header("Player Settings")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoviment();
    }

    private void InitBounds()
    {
        //Get the camera's size according to the world
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnMove(InputValue value)
    {
        //Player Inputs
        playerMovimentInput = value.Get<Vector2>();
    }

    private void PlayerMoviment()
    {
        //Player Moviment, considering the scene's limits to not let the player goes out of the camera
        Vector3 delta = playerMovimentInput * playerSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    
}
