using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] peristentObjects = new GameObject[5];

    public int objectIndex;

    void Awake()
    {
        if (peristentObjects[objectIndex] == null)
        {
            peristentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (peristentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }
    }
}
