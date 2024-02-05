using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightning : MonoBehaviour
{
    [SerializeField]
    private GameObject lightning;
    [SerializeField]
    private float spawnHeightAdd;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SpawnLightning(Transform target)
    {
        Vector3 spawnPosition = target.position;

        spawnPosition.y += spawnHeightAdd;

        Instantiate(lightning, spawnPosition, Quaternion.identity);
    }
}
