using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject transitionsContainer;

    public GameObject loadingText;
    public GameObject loadingAnim;

    public Canvas canvas;

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
    }

    private void Start()
    {
        sceneTransitions = transitionsContainer.GetComponentsInChildren<SceneTransition>();
    }

    public void LoadScene(string sceneName, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    }

    private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        SceneTransition transition = sceneTransitions.First(t => t.name  == transitionName);
        canvas.sortingOrder = 100;

        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return transition.TransitionIn();

        scene.allowSceneActivation = true;

        loadingText.SetActive(false);
        loadingAnim.SetActive(false);

        canvas.sortingOrder = 0;

        yield return transition.TransitionOut();
    }
}
