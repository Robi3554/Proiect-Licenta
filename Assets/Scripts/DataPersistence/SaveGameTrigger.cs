using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTrigger : MonoBehaviour
{
    private bool isSaved = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && isSaved == false)
        {
            DataPersistenceManager.Instance.SaveGame();
            isSaved = true;
        }
    }
}
