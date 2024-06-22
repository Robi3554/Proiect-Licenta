using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SimpleDoor : MonoBehaviour
{
    internal CompositeCollider2D cc;
    internal TilemapRenderer tr;

    public bool isClosed = false;

    void Start()
    {
        cc = GetComponent<CompositeCollider2D>();

        tr = GetComponent<TilemapRenderer>();
    }

    public void DisableTriggerCollider()
    {
        if (cc.isTrigger)
        {
            cc.isTrigger = false;
        }
    }

    public void EnableTileMapRenderer()
    {
        if (!tr.enabled)
        {
            tr.enabled = true;
        }
    }

    public void CloseDoor()
    {
        EnableTileMapRenderer();
        DisableTriggerCollider();
    }
}
