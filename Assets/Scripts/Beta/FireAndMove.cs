/*
 * Zachary Speckan
 * 04/01/24
 * Teleports and fires a bullet at the player several times
 * 
 * teleport - Teleport script
 * fire - EnemyPredictShooting script
 * 
 * CHANGE LOG
 * Zach - 04/08/24 - Attacks speed up when boss is at half health
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAndMove : MonoBehaviour
{
    Teleport teleport;
    EnemyPredictShooting fire;
    BossFightDirections directions;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        teleport = GetComponent<Teleport>();
        fire = GetComponent<EnemyPredictShooting>();
        directions = GetComponent<BossFightDirections>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    StartCoroutine(TeleSpam());
        //}
    }

    public IEnumerator TeleSpam()
    {
        for (int i = 0; i < 3; i++)
        {
            anim.SetTrigger("Teleporting");
            StartCoroutine(teleport.MoveIt());
            yield return new WaitForSeconds(1.75f - directions.speedUp);
            fire.ShootToKill();
            yield return new WaitForSeconds(1.0f - directions.speedUp);
            anim.SetTrigger("Throwing");
        }
    }
}
