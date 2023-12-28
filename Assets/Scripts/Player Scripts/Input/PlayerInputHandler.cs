using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    private GameObject currentOneWayPlatform;

    [SerializeField]
    private BoxCollider2D bc;

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

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        rawMoveInput = context.ReadValue<Vector2>();

        normalizedInputX = Mathf.RoundToInt(rawMoveInput.x);

        normalizedInputY = Mathf.RoundToInt(rawMoveInput.y);

        if(currentOneWayPlatform != null && Keyboard.current.sKey.wasPressedThisFrame)
        {
            StartCoroutine(DisableCollision());
        }
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("OneWayPlatform"))
            currentOneWayPlatform = col.gameObject;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("OneWayPlatform"))
            currentOneWayPlatform = null;
    }

    private IEnumerator DisableCollision()
    {
        CompositeCollider2D platformCol = currentOneWayPlatform.GetComponent<CompositeCollider2D>();

        Physics2D.IgnoreCollision(bc, platformCol);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(bc, platformCol, false);
    }
}

public enum CombatInputs
{
    primary,
    secondary
}
