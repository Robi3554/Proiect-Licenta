using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private Player playerScript;

    private PlayerData data;

    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameObject[] playerTag = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject obj in playerTag)
        {
            playerScript = obj.GetComponent<Player>();

            if(playerScript != null)
            {
                data = playerScript.playerData;
            }
        }
    }

    private void Start()
    {
        speed = data.moveVelocity;

        Debug.Log("Speed is: " + speed);
    }

    private void FixedUpdate()
    {
        
    }

}