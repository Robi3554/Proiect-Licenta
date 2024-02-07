using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    private bool isOpen = false;

    [Header("Player Action")]
    [SerializeField]
    private PlayerInput playerInput;

    public InputAction inventoryAction;

    private void OnEnable()
    {
        inventoryAction.Enable();
    }

    private void OnDisable()
    {
        inventoryAction.Disable();
    }

    private void Update()
    {
        if (inventoryAction.triggered)
        {
            ToggleInventoryMenu();
        }
    }
    private void ToggleInventoryMenu()
    {
        if (!isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void Open()
    {
        playerInput.SwitchCurrentActionMap("UI");
        Time.timeScale = 0f;
        inventoryMenu.SetActive(true);
        isOpen = true;
    }

    private void Close()
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
        Time.timeScale = 1f;
        inventoryMenu.SetActive(false);
        isOpen = false;
    }
}
