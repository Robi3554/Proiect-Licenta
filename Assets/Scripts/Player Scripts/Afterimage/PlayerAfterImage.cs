using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAfterImage : MonoBehaviour
{
    [SerializeField]
    private float activetime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaSet = 0.8f;
    [SerializeField]
    private float alphaDecay = 0.5f;

    private GameObject player;
    private Transform playerTr;

    private SpriteRenderer sr;
    private SpriteRenderer playerSr;

    private Color color;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTr = player.transform;
        playerSr = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        sr.sprite = playerSr.sprite;
        transform.position = playerTr.position;
        transform.rotation = playerTr.rotation;
        transform.localScale = playerTr.localScale;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha -= alphaDecay * Time.deltaTime;
        color = new Color(1f, 1f, 1f, alpha);
        sr.color = color;

        if(Time.time >= (timeActivated + activetime))
        {
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }
    }
}
