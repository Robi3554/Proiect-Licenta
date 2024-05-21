using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject firstSelected;

    protected virtual void OnEnable()
    {
        StartCoroutine(SetFirstSelected(firstSelected));
    }

    public IEnumerator SetFirstSelected(GameObject firstSelectedObject)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(firstSelectedObject);
    }
}
