using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            LevelManager.Instance.LoadScene(sceneName, "CircleWipe");
            col.GetComponentInChildren<PlayerStats>().IncreaseHealth(999);
        }
    }
}
