using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoatInputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private BoatManager motor;
    private BoatLook look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<BoatManager>();
        look = GetComponent<BoatLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Tell the playermotor to move using the value from our movement action.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
