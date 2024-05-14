using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorManager : MonoBehaviour
{
    private RoomManager roomManager;

    internal CompositeCollider2D cc;
    internal TilemapRenderer tr;

    void Awake()
    {
        cc = GetComponent<CompositeCollider2D>();

        tr = GetComponent<TilemapRenderer>();

        roomManager = FindObjectOfType<RoomManager>();
    }

    public void EnableTriggerCollider()
    {
        if (!cc.isTrigger)
        {
            cc.isTrigger = true;
        }
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

    public void DisableTileMapRenderer()
    {
        if (tr.enabled)
        {
            tr.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            roomManager.enabled = true;
        }
    }
}
