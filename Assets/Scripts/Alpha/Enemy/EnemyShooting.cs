/*
 * Zachary Speckan
 * 02/23/24
 * Shoots a bullet at the player.
 * 
 * targetingDistance - Max distance the enemy will shoot the player at
 * targetingTimer - How long the enemy will wait until firing another bullet
 * bullet - The bullet prefab
 * bulletPos - Where the bullet will respawn at
 * 
 * CHANGE LOG
 * Zach - 02/23/24 - Added comments.
 * Zach - 02/29/24 - Bullets can predict where the player will be
 * Dylan/Colin - 03/04/24 - changed call from "shoot" to "Shoot" to stay consistant
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public delegate void EnemyShootingDelegate();
    public EnemyShootingDelegate enemyShooting;

    //used to modify the distance aquisition and consistency of the shots
    public float targetingDistance = 25.0f;
    public float targetingTimer = 2.0f;

    public GameObject bullet;
    public Transform bulletPos;

    private float callCountdown;
    private GameObject player;

    public AudioSource src;
    public AudioClip fireClip;

    // Start is called before the first frame update
    void Start()
    {
        callCountdown = targetingTimer;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // Gets the distance the player is from the enemy
        float distance = Vector2.Distance(transform.position, player.transform.position);
        // Checks if the player is close enough
        if (distance < targetingDistance && callCountdown < 0)
        {
            callCountdown = targetingTimer;
            Bullet();
        }
        if (callCountdown > 0) { 
            callCountdown -= Time.deltaTime;
        }
    }

    // Shoots the bullet
    void Bullet()
    {
        animate();
        Invoke("Shot", .6f);
        
        
    }

    private void Shot()
    {
        src.clip = fireClip;
        src.Play();
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    void animate() {
        if (enemyShooting != null)
        {
            //this calls for the animator to start animating the attack.
            enemyShooting();
        }
    }
}