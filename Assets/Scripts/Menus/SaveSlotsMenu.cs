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

    [SerializeField]
    private ConfirmationMenu confirmationMenu;

    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClick(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        if (isLoadingGame)
        {
            DataPersistenceManager.Instance.ChangeSelectedProfileID(saveSlot.GetProfileID());
            SaveGameAndLoadScene();
        }
        else if (saveSlot.HasData)
        {
            confirmationMenu.ActivateMenu(
                "Starting a New Game in this slot will override previously saved data! Proceed?",
                () =>
                {
                    DataPersistenceManager.Instance.ChangeSelectedProfileID(saveSlot.GetProfileID());
                    DataPersistenceManager.Instance.NewGame();
                    SaveGameAndLoadScene();
                },
                () =>
                {
                    ActivateMenu(isLoadingGame);
                }
            );
        }
        else
        {
            DataPersistenceManager.Instance.ChangeSelectedProfileID(saveSlot.GetProfileID());
            DataPersistenceManager.Instance.NewGame();
            SaveGameAndLoadScene();
        }
    }

    public void SaveGameAndLoadScene()
    {
        DataPersistenceManager.Instance.SaveGame();

        //SceneManager.LoadSceneAsync("Level1");

        LevelManager.Instance.LoadScene("Level1", "CircleWipe");
    }

    public void ActivateMenu(bool isLoadingGame)
    {
        gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.Instance.GetAllProfilesGameData();

        backButton.interactable = true;

        GameObject firstSelected = backButton.gameObject;
        foreach(SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileID(), out profileData);
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

        Button firstSelectedButton = firstSelected.GetComponent<Button>();

        SetFirstSelected(firstSelectedButton);
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

    public void OnClearClick(SaveSlot saveSlot)
    {
        DisableMenuButtons();

        confirmationMenu.ActivateMenu(
            "Data is being deleted! Are you sure?",
            () =>
            {
                DataPersistenceManager.Instance.DeleteProfileData(saveSlot.GetProfileID());
                ActivateMenu(isLoadingGame);
            },
            () =>
            {
                ActivateMenu(isLoadingGame);
            }
        );
    }

    public void OnBackClick()
    {
        menu.ActivateMenu();
        DeactivateMenu();
    }
}
