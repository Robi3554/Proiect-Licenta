using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    public CameraSwitcher swithcer;

    private void Start()
    {
        swithcer = FindObjectOfType<CameraSwitcher>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            swithcer.SwitchBoundingShape();
            LevelManager.Instance.LoadScene(sceneName, "CircleWipe");
            col.GetComponentInChildren<PlayerStats>().IncreaseHealth(999);
        }
    }
}
