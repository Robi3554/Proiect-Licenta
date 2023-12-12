using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFireEffect : MonoBehaviour
{
    private int count = 0;

    public void DestroyObject()
    {
        count++;
        if(count == 2)
        {
            Destroy(gameObject);
        }
    }
}
