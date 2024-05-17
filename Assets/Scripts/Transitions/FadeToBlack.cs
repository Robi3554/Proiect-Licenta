using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FadeToBlack : MonoBehaviour
{
    public CanvasGroup fadeToBlack;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void TransitionIn()
    {
        var fade = fadeToBlack.DOFade(1f, 1f).OnComplete(FadeCompleted);
    }

    public void FadeCompleted()
    {
        Debug.Log("Completed");
    }
}
