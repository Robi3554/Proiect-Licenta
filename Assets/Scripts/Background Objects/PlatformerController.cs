using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the contact normal to determine the collision side
            Vector2 contactNormal = collision.contacts[0].normal;

            // Check if the collision is from the top
            if (Vector2.Dot(contactNormal, Vector2.up) > 0.9f)
            {

            }
            else
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);

                Invoke("EnableCollision", 0.1f);
            }

            Debug.Log("Collision detected!");
        }
    }

    private void EnableCollision()
    {
        CompositeCollider2D platformCollider = GetComponent<CompositeCollider2D>();
        BoxCollider2D[] playerColliders = GameObject.FindGameObjectWithTag("Player").GetComponents<BoxCollider2D>();

        foreach (BoxCollider2D playerCollider in playerColliders)
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }

        Debug.Log("Enable Collision!");
    }
}
