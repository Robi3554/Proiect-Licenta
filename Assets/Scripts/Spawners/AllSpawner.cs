using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSpawner : MonoBehaviour
{
    [SerializeField]
    protected string id;

    [ContextMenu("Generate id")]
    protected virtual void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }
}
