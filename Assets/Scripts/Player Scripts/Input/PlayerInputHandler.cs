using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 rawMoveInput { get; private set; }
    public Vector2 rawDashDirectionInput { get; private set; }
    public Vector2Int dashDirectionInput { get; private set; }

    public int normalizedInputX { get; private set; }
    public int normalizedInputY { get; private set; }
    public bool jumpInput { get; private set; }
    public bool jumpInputStop { get; private set; }
    public bool grabInput { get; private set; }
    public bool dashInput { get; private set; }
    public bool dashInputStop { get; private set; }

    public bool[] attackInputs { get; private set; }

    private float jumpInputStartTime;
    private float dashInputStartTime;

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        attackInputs = new bool[count];

        cam = Camera.main;
    }

    private void Update()
    {
        CheckJumpInputTime();
        CheckDashInputTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackInputs[(int)CombatInputs.primary] = true;
        }

        if (context.canceled)
        {
            attackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            attackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        rawMoveInput = context.ReadValue<Vector2>();

        //if(Mathf.Abs(rawMoveInput.x) > 0.5f)
        //{
        //    normalizedInputX = (int)(rawMoveInput * Vector2.right).normalized.x;
        //}
        //else
        //{
        //    normalizedInputX = 0;
        //}

        //if (Mathf.Abs(rawMoveInput.y) > 0.5f)
        //{
        //    normalizedInputY = (int)(rawMoveInput * Vector2.up).normalized.y;
        //}
        //else
        //{
        //    normalizedInputY = 0;
        //}

        normalizedInputX = Mathf.RoundToInt(rawMoveInput.x);

        normalizedInputY = Mathf.RoundToInt(rawMoveInput.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInput = true;
            jumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            jumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            grabInput = true;
        }
        else if (context.canceled)
        {
            grabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            dashInput = true;
            dashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            dashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        rawDashDirectionInput = context.ReadValue<Vector2>();

        if (playerInput.currentControlScheme == "Keyboard")
        {
            rawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)rawDashDirectionInput) - transform.position;
        }

        dashDirectionInput = Vector2Int.RoundToInt(rawDashDirectionInput.normalized);
    }

    public void UseDashInput() => dashInput = false;

    public void UseJumpInput() => jumpInput = false;

    private void CheckJumpInputTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            jumpInput = false;
        }
    }

    private void CheckDashInputTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            dashInput = false;
        }
    }
}

public enum CombatInputs
{
    primary,
    secondary
}
