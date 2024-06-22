using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    private PauseMenu pauseMenu;

    internal Description description;

    private float currentTimeScale;

    public GameObject inventoryMenu;
    public bool isOpen = false;
    public ItemSlot[] slots;

    [Header("Player Action")]
    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        description = GetComponent<Description>();

        pauseMenu = GetComponentInParent<PauseMenu>();
    }

    public  void ToggleInventoryMenu()
    {
        if (pauseMenu.isPaused)
        {
            return;
        }

        if (!isOpen)
        {
            currentTimeScale = Time.timeScale;
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
        Time.timeScale = currentTimeScale;
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
