using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStartScreen : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadStart()
    {
        LevelManager.Instance.LoadScene("StartScene", "CircleWipe");
    }
}
