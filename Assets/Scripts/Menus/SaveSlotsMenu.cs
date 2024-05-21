using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    private SaveSlot[] saveSlots;

    [SerializeField]
    private MainMenu menu;

    [SerializeField]
    private Button backButton;

    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClick(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        DataPersistenceManager.Instance.ChangeSelectedProfileID(saveSlot.GetProfileId());

        if (!isLoadingGame)
        {
            DataPersistenceManager.Instance.NewGame();
        }

        SceneManager.LoadSceneAsync("Level1");
    }

    public void ActivateMenu(bool isLoadingGame)
    {
        gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.Instance.GetAllProfilesGameData();

        GameObject firstSelected = backButton.gameObject;
        foreach(SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);

            if(profileData == null & isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
                if (firstSelected.Equals(backButton.gameObject))
                {
                    firstSelected = saveSlot.gameObject;
                }
            }
        }

        StartCoroutine(SetFirstSelected(firstSelected));
    }

    public void DeactivateMenu() 
    {
        gameObject.SetActive(false);
    }

    public void DisableMenuButtons()
    {
        foreach(SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }

        backButton.interactable = false;
    }

    public void OnBackClick()
    {
        menu.ActivateMenu();
        DeactivateMenu();
    }
}
