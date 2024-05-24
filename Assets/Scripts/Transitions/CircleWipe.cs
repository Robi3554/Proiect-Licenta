using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CircleWipe : SceneTransition
{
    public Image circle;

    public override IEnumerator TransitionIn()
    {
        circle.rectTransform.anchoredPosition = new Vector2(-2200f, 0);
        var wipe = circle.rectTransform.DOAnchorPosX(0f, 1f);
        yield return wipe.WaitForCompletion();
    }

    public override IEnumerator TransitionOut()
    {
        var wipe = circle.rectTransform.DOAnchorPosX(2200f, 1f);
        yield return wipe.WaitForCompletion();
    }
}
