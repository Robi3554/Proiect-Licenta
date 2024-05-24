using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrossFade : SceneTransition
{
    public CanvasGroup crossFade;

    public override IEnumerator TransitionIn()
    {
        var fade = crossFade.DOFade(1f, 1f);
        yield return fade.WaitForCompletion();
    }

    public override IEnumerator TransitionOut()
    {
        var fade = crossFade.DOFade(0f, 1f);
        yield return fade.WaitForCompletion();
    }
}
