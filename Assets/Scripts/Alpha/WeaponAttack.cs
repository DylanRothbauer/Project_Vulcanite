/*
 * Dylan Rothbauer
 * 02/28/24
 * A simple script to attach to weapons
 * 
 * CHANGE LOG
 * 02/28/24 - Created script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public PlayerStats playerStats;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                //Debug.Log("EnemyHealth component retrieved!");
                //Debug.Log(playerStats.damage);
                enemyHealth.TakeDamage(playerStats.damage);
            }
        }

        if (collision.gameObject.CompareTag("LootBox") || collision.gameObject.CompareTag("Obsticle"))
        {
            Destroy(gameObject);
        }
    }
}
