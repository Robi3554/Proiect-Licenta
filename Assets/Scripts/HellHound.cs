using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : MonoBehaviour
{
    private Transform target;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    [SerializeField]
    private BoxCollider2D bc;

    private Player playerScript;

    private PlayerData data;

    private Vector2 myDir;

    private float speed;

    private bool chasePlayer = false;

    [SerializeField]
    private float distance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        GameObject[] playerTag = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject obj in playerTag)
        {
            playerScript = obj.GetComponent<Player>();
            target = obj.transform;

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

        anim.SetBool("idle", true);
    }

    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        myDir = direction;
    }

    private void FixedUpdate()
    {
        float targetDistance = Vector2.Distance(target.position, transform.position);

        if (targetDistance > distance)
        {
            //chasePlayer = true;
        }

        Move();
    }

    private void Move()
    {
        if (chasePlayer)
        {
            myDir.y = 0;
            rb.velocity = new Vector2(myDir.x, myDir.y) * speed;
            anim.SetBool("idle", false);
            anim.SetBool("chase", true);
        }       
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            chasePlayer = false;
            anim.SetBool("chase", false);
            anim.SetBool("idle", true);

           

        }

        Debug.Log("Reached Player!");
    }

}