using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextHelper : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] texts;

    void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>(true);
    }

    public void EnableTexts()
    {
        foreach (TextMeshProUGUI text in texts)
        {
            text.enabled = true;
        }
    }

    public void DisableTexts()
    {
        foreach (TextMeshProUGUI text in texts)
        {
            text.enabled = false;
        }
    }

}
