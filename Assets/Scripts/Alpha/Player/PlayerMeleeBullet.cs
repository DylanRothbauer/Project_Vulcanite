/*
 * Colin Kintzinger
 * 04/02/24
 * Weapon parent class for the combat system.
 * 
 * CHANGE LOG
 * colin-4/02/24-Finished up on the code and added comments
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public float lifeTime = .2f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //sets the velocity of the bullet and also applies range based on time 
        rb.velocity = transform.up * speed; 
        if (lifeTime < 0)
        { 
            Destroy(gameObject);
        }
        lifeTime -= Time.deltaTime * 1;

    }
}
