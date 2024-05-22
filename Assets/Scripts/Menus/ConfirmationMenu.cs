using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ConfirmationMenu : Menu
{
    [Header("Components")]
    [SerializeField]
    private TextMeshProUGUI display;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private Button cancelButton;

    public void ActivateMenu(string displayText, UnityAction confirm, UnityAction cancel)
    {
        gameObject.SetActive(true);

        display.text = displayText;    

        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();

        confirmButton.onClick.AddListener(() =>
        {
            DeactivateMenu();
            confirm();
        });

        cancelButton.onClick.AddListener(() =>
        {
            DeactivateMenu();
            cancel();
        });
    }

    private void DeactivateMenu()
    {
        gameObject.SetActive(false);
    }
}
