/*
 * Dylan Rothbauer
 * 02/28/24
 * A ranged enemy script to flee when player is close
 * 
 * CHANGE LOG
 * Dylan - 02/28/24 - Created script and used PlayerController code to restrict it to the scene to not go out of bounds
 * Dylan/Colin - 03/04/24 - polished code and spacing and commented
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Transform player;
    public float fleeDistance = 5f;
    public float speed = 5f;
    public float xDistance = 2.0f;
    public float yDistance = 2.0f;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < fleeDistance)
        {
            Flee();
        }

        // Partialy prevents out of bound glitch (for player too)
        if (transform.position.x < -xDistance)
        {
            transform.position = new Vector3(-xDistance, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xDistance)
        {
            transform.position = new Vector3(xDistance, transform.position.y, transform.position.z);
        }

        
        if (transform.position.y < -yDistance)
        {
            transform.position = new Vector3(transform.position.x, -yDistance, transform.position.z);
        }
        if (transform.position.y > yDistance)
        {
            transform.position = new Vector3(transform.position.x, yDistance, transform.position.z);
        }

    }

    private void Flee()
    {
        // Calculate a position opposite to the player
        Vector3 fleeDirection = transform.position - player.position;
        Vector3 fleePosition = transform.position + fleeDirection.normalized * fleeDistance;

        // Move towards the flee position
        transform.position = Vector3.MoveTowards(transform.position, fleePosition, Time.deltaTime * speed);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(collision.gameObject);
        }
    }
}
