using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;
using System.Collections;

public class Fader : MonoBehaviour
{
    public float fadeDuration = 1.0f;

    private TilemapRenderer tileRenderer;

    private void Awake()
    {
        tileRenderer = GetComponent<TilemapRenderer>();

        if (tileRenderer == null)
        {
            Debug.LogError("TileRenderer component not found.");
            return;
        }
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        Debug.Log("Player entered collider. Fading out...");
    //        StartCoroutine(FadeOut());
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        Debug.Log("Player exited collider. Fading in...");
    //        StartCoroutine(FadeIn());
    //    }
    //}

    public void FadeOutTo()
    {
        StartCoroutine(FadeOut());
    }

    public void FadeInTo()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            Color color = tileRenderer.material.color;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            tileRenderer.material.color = color;

            timer += Time.deltaTime;
            yield return null;
        }

        Color finalColor = tileRenderer.material.color;
        finalColor.a = 0f;
        tileRenderer.material.color = finalColor;
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            Color color = tileRenderer.material.color;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            tileRenderer.material.color = color;

            timer += Time.deltaTime;
            yield return null;
        }

        Color finalColor = tileRenderer.material.color;
        finalColor.a = 1f;
        tileRenderer.material.color = finalColor;
    }
}
