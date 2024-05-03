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
using Unity.VisualScripting;
using UnityEngine;
//derrived class from parent
public class Range : Weapon
{
    public GameObject bullet;
    public AudioSource src;
    public AudioClip throwFire;

    //public string bulletInResorces = "Triangle";
    //public string attackWeaponInResorces = "PlayerStats";

    protected new void Start()
    {
        //calls the start function from the parent class
        base.Start();
    }
    //instantiates ranged bullet
    public override void Attack()
    {

        if (bullet != null && bulletSpawn != null)
        {
            //Debug.LogError((Singleton.Instance.weapon));
            Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            Instantiate(bullet, bulletSpawn.position + offset, Quaternion.Euler(0, 0, angle));
            src.clip = throwFire;
            src.Play();
        }
        else
        {
            Debug.LogError("Bullet or bulletSpawn is null!");
        }
    }
   
}