using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private PlayerControls playerInput;

    [SerializeField] float speed = 2f;

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    void Awake()
    {
        playerInput = new PlayerControls();
    }

    void Update()
    {
        Vector2 movementInput = playerInput.Player.Aim.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0f);
        transform.Translate(move * speed * Time.deltaTime);        
    }    
}
