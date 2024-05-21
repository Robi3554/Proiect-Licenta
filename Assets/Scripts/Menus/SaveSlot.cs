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

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        if(data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            percentageText.text = data.GetPercentageComplete() + "% COMPLETE";
            currentHealthText.text = "Current Health : " + data.curentHealth;
        }
    }

    public string GetProfileId()
    {
        return profileID;
    }

    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable;
    }
}
