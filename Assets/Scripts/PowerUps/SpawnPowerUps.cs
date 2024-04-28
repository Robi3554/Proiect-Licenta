using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public PowerUpList list;

    void Start()
    {
        int randInt = Random.Range(0, list.powerUps.Length);

        SpawnPowerUp(randInt);
    }

    private void SpawnPowerUp(int index)
    {
        if (index >= 0 && index < list.powerUps.Length)
        {
            GameObject prefab = list.powerUps[index];
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Invalid index specified for spawning GameObject.");
        }
    }
}
