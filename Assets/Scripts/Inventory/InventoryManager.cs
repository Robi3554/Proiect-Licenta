using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    internal Description description;

    public GameObject inventoryMenu;
    private bool isOpen = false;
    public ItemSlot[] slots;

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

    private void Awake()
    {
        description = GetComponent<Description>();
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

    public void AddPowerUp(string powerUpName, Sprite powerUpSprite, string powerUpDescription)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isFull == false && slots[i].powerUpName == powerUpName || slots[i].quantity == 0)
            {
                slots[i].AddPowerUp(powerUpName, powerUpSprite, powerUpDescription);
                return;
            }
        }
    }

    public void DeselectSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].selectPanel.SetActive(false);
            slots[i].isSelected = false;
        }
    }
}
