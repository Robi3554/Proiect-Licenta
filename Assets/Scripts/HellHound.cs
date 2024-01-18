using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : MonoBehaviour
{
    public Transform target; // Reference to the target GameObject
    public float followDistance = 5f; // Distance to start following the target
    public float followSpeed = 5f; // Speed at which the object will follow the target

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction from the follower to the target
            Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;

            // Ignore the vertical (Z) axis
            direction.y = 0;

            // Calculate the position that is 'followDistance' away from the target
            Vector2 targetPosition = (Vector2)target.position - direction * followDistance;

            // Move the follower towards the calculated position with smooth interpolation
            Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * followSpeed);

            // Update the position of the Rigidbody2D
            rb.MovePosition(new Vector2(newPosition.x, transform.position.y));

            anim.SetBool("idle", false);
            anim.SetBool("walk", true);
        }
    }
}