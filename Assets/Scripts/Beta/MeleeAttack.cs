/*
 * Zachary Speckan
 * 03/31/24
 * Sends out an ice blast.
 * 
 * blast - The ice blast object
 * 
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject blast;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    BlastIt();
        //}
    }

    public void BlastIt()
    {
        Instantiate(blast, transform.position, Quaternion.identity);
    }
}
