/*
 * Zachary Speckan
 * 02/23/24
 * Removes objects outside the level
 * 
 * left/upper/lower/rightBound - The position an object will disappear at the respective coordinate
 * 
 * CHANGE LOG
 * Zach - 02/23/24 - Added comments.
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public float leftBound = -25;
    public float upperBound = 6;
    public float lowerBound = -6;
    public float rightBound = 25;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if any of the bounds have been exceeded
        if (transform.position.x < leftBound || transform.position.y > upperBound 
            || transform.position.y < lowerBound || transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
