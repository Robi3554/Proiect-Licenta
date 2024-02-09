using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("PowerUp Data")]
    internal string powerUpName;
    internal Sprite powerUpSprite;
    public bool isFull;
    public string powerUpDescritpion;
    public Sprite emptySprite;

    [Header("PowerUp Slot")]
    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image powerUpImage;
    [SerializeField]
    internal int quantity;
    [SerializeField]
    private int maxPowerUpInSlot;

    [Header("Description Text")]
    public Image descriptionImage;
    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public GameObject selectPanel;
    public bool isSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Canvas").GetComponent<InventoryManager>();

        descriptionImage = inventoryManager.description.descriptionImage;
        nameText = inventoryManager.description.nameText;
        descriptionText = inventoryManager.description.descriptionText;
    }

    public void AddPowerUp(string powerUpName, Sprite powerUpSprite, string powerUpDescription)
    {
        this.powerUpName = powerUpName;

        this.powerUpSprite = powerUpSprite;
        powerUpImage.sprite = powerUpSprite;
        powerUpImage.enabled = true;

        this.powerUpDescritpion = powerUpDescription;

        quantity = int.Parse(quantityText.text);
        quantity++;
        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        if (quantity == maxPowerUpInSlot)
            isFull = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectSlots();
        selectPanel.SetActive(true);
        isSelected = true;
        nameText.text = powerUpName;
        descriptionText.text = powerUpDescritpion;
        descriptionImage.sprite = powerUpSprite;
        if (descriptionImage.sprite == null)
            descriptionImage.sprite = emptySprite;
    }

    public void OnRightClick()
    {

    }
}
