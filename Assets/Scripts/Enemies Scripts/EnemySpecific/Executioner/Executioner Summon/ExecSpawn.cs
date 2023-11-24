using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
public class ExecSpawn : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Transform target;
    
    [SerializeField]
    private float 
        chaseRadius,
        speed,
        maxHealth;

    private Vector3 homePos;

    private float currentHealth;

    [HideInInspector]
    public int facingDir;

    #region Components
    protected Rigidbody2D rb;
    protected Animator anim;
    protected SpriteRenderer sr;
    #endregion

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        homePos = gameObject.transform.position;

        anim.SetBool("idle", true);

        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        if(currentHealth > 0)
        {
            CheckDistance();
        }

        Flip();
    }

    private void CheckDistance()
    {
        float targetDistance = Vector3.Distance(target.position, transform.position);

        if (targetDistance <= chaseRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(temp);
        }
        else if(targetDistance > chaseRadius && transform.position != homePos)
        {
            Vector3 temp2 = Vector3.MoveTowards(transform.position, homePos, speed * Time.deltaTime);
            rb.MovePosition(temp2);
        }
    }
    private void Flip()
    {
        if(transform.position.x > target.transform.position.x)
        {
            sr.flipX = true;
            facingDir = -1;
        }
        else
        {
            sr.flipX = false;
            facingDir = 1;
        }
    }

    void IDamageable.Damage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Debug.Log("Health is 0!");
            SetDeath();
        }
    }

    private void SetDeath()
    {
        anim.SetBool("death", true);
        anim.SetBool("idle", false);

        rb.velocity = new Vector2(0f, 0f);

        Destroy(gameObject, 0.75f);
    }
}
