/*
 * Zachary Speckan
 * 03/31/24
 * Detects what side of the boss the player is standing on and places/rotates the ice blast accordingly
 * 
 * player - The player
 * queen - The boss
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastDirection : MonoBehaviour
{
    private GameObject player;
    private GameObject queen;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        queen = GameObject.FindGameObjectWithTag("Boss");
        queen.GetComponent<MeleeAttack>();
        
        
        if (Mathf.Abs(player.transform.position.x - queen.transform.position.x) > Mathf.Abs(player.transform.position.y - queen.transform.position.y))
        {
            if (player.transform.position.x < queen.transform.position.x)
            {
                transform.position = new Vector3(queen.transform.position.x - 2.0f, queen.transform.position.y, queen.transform.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 90);
                Debug.Log("Left");
            }
            else
            {
                transform.position = new Vector3(queen.transform.position.x + 2.0f, queen.transform.position.y, queen.transform.position.z);
                transform.rotation = Quaternion.Euler(0, 0, -90);
                Debug.Log("Right");
            }
        }
        else
        {
            if (player.transform.position.y > queen.transform.position.y)
            {
                transform.position = new Vector3(queen.transform.position.x, queen.transform.position.y + 2.0f, queen.transform.position.z);
                Debug.Log("Top");
            }
            else
            {
                transform.position = new Vector3(queen.transform.position.x, queen.transform.position.y - 2.0f, queen.transform.position.z);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                Debug.Log("Bottom");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
