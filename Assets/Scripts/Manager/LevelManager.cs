using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject transitionsContainer;

    public TextMeshProUGUI loadingText;
    public Image loadingAnim;

    private Canvas canvas;

    private SceneTransition[] sceneTransitions;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneUnloaded += OnSceneUnloaded;

        canvas = GetComponent<Canvas>();
    }

    private void OnSceneUnloaded(Scene scene)
    {
        HandleSceneEnd();
    }

    private void Start()
    {
        sceneTransitions = transitionsContainer.GetComponentsInChildren<SceneTransition>();
    }

    public void LoadScene(string sceneName, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    }

    private void HandleSceneEnd()
    {
        GameObject canvasObj = GameObject.Find("LevelManager");

        if(canvasObj != null )
        {
            canvas = canvasObj.GetComponent<Canvas>();

            canvas.sortingOrder = 0;
        }
    }

    private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        SceneTransition transition = sceneTransitions.First(t => t.name  == transitionName);
        canvas.sortingOrder = 20;

        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        loadingText.enabled = true;
        loadingAnim.enabled = true;

        yield return transition.TransitionIn();

        scene.allowSceneActivation = true;

        loadingText.enabled = false;
        loadingAnim.enabled = false;

        yield return transition.TransitionOut();
    }
}
