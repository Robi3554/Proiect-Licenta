using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Porfile")]
    [SerializeField]
    private string profileID = "";

    [Header("Content")]
    [SerializeField]
    private GameObject noDataContent;
    [SerializeField]
    private GameObject hasDataContent;
    [SerializeField]
    private TextMeshProUGUI percentageText;
    [SerializeField]
    private TextMeshProUGUI currentHealthText;

    [SerializeField]
    private Button clearButton;

    private Button saveSlotButton;

    public bool HasData { get; private set; } = false; 

    private void Awake()
    {
        saveSlotButton = GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        if(data == null)
        {
            HasData = false;
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            clearButton.gameObject.SetActive(false);
        }
        else
        {
            HasData = true;
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            clearButton.gameObject.SetActive(true);

            percentageText.text = data.GetPercentageComplete() + "% COMPLETE";
            currentHealthText.text = "Current Health : " + data.curentHealth;
        }
    }

    public string GetProfileID()
    {
        return profileID;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
        clearButton.interactable = interactable;
    }
}
