using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public GameObject[] positions;

    public PowerUpList list;

    void Start()
    {
        int randInt;

        int[] alreadyChosen = new int[positions.Length];

        for (int i = 0; i < positions.Length; i++)
        {
            do
            {
              randInt = Random.Range(0, list.powerUps.Length);
            } while (alreadyChosen.Contains(randInt));

            alreadyChosen[i] = randInt;

            SpawnPowerUp(randInt, i);
        }
    }

    private void SpawnPowerUp(int index, int n)
    {
        if (index >= 0 && index < list.powerUps.Length)
        {
            GameObject prefab = list.powerUps[index];
            Instantiate(prefab, positions[n].transform.position, Quaternion.identity);
        }
    }
}
