using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    private GameObject currentOneWayPlatform;

    [SerializeField]
    private BoxCollider2D bc;

    public delegate void PowerUpHandler(Collider2D col);

    public event PowerUpHandler PowerUp;

    public Vector2 rawMoveInput { get; private set; }
    public Vector2 rawDashDirectionInput { get; private set; }
    public Vector2Int dashDirectionInput { get; private set; }

    public float moveInput { get; private set; }

    public int normalizedInputX { get; private set; }
    public int normalizedInputY { get; private set; }
    public bool jumpInput { get; private set; }
    public bool jumpInputStop { get; private set; }
    public bool grabInput { get; private set; }
    public bool dashInput { get; private set; }
    public bool dashInputStop { get; private set; }

    public bool healInput { get; private set; }

    public bool[] attackInputs { get; private set; }

    private float jumpInputStartTime;
    private float dashInputStartTime;

    private bool isInTrigger;

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
        string currentScheme = playerInput.currentControlScheme;


        if(currentScheme == "Keyboard")
        {
            moveInput = context.ReadValue<float>();

            normalizedInputX = Mathf.RoundToInt(moveInput);
        }
        else if(currentScheme == "Gamepad")
        {
            rawMoveInput = context.ReadValue<Vector2>();

            normalizedInputX = Mathf.RoundToInt(rawMoveInput.x);
        }

    }

    public void OnDropInput(InputAction.CallbackContext context)
    {
        if(context.started && currentOneWayPlatform != null)
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

            //rawDashDirectionInput = rawDashDirectionInput.normalized;
        }

        dashDirectionInput = Vector2Int.RoundToInt(rawDashDirectionInput.normalized);
    }

    public void OnActionInput(InputAction.CallbackContext context)
    {
        if (isInTrigger)
        {
            if (context.started)
            {
                PowerUp?.Invoke(bc);
            }
        }
    }

    public void OnHealInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            healInput = true;
            Debug.Log("Heal!");

        }
        else if (context.canceled)
        {
            healInput = false;
        }
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PowerUp"))
            isInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PowerUp"))
            isInTrigger = false;
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
