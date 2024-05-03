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

public class Weapon : MonoBehaviour
{
    protected Transform aimTransform;
    protected Transform bulletSpawn;


    public float fireDelay = 1f;
    public float attackTime = .5f;
    public float timer = 0;
    protected float angle;
    protected GameObject player;
    public float gettingAngle;

    //public PlayerStats playerStats;
    // Start is called before the first frame update
    protected void Start()
    {
        UpdatePlayerAim();

    }

    // Update is called once per frame
    void Update()
    {
        Aiming();

        gettingAngle = angle;
        //sets the delay so player can't spam the melee attack
        if (Input.GetMouseButton(0) && timer <= 0 && Singleton.Instance.GetWeapon() != null)
        {
            timer = fireDelay;
            Attack();
            

        }
        if (timer > 0)
        {
            timer -= Time.deltaTime * 1;
        }
    }
    //virtual method for attacking
    public virtual void Attack()
    {

    }
    //allows the player object to get the angle for the positioning of the melee object 
    private void Aiming()
    {
        if (aimTransform == null)
        {
            UpdatePlayerAim();
        }

        if (aimTransform != null)
        {
            Vector3 mousePosition = GetMouseWorldPositon();
            Vector3 aimDirection = (mousePosition - player.transform.position).normalized;
            angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            //Debug.Log(aimTransform);
            //Debug.Log(angle);
            if (aimTransform != null)
            {
                aimTransform.eulerAngles = new Vector3(0, 0, angle);
            }
            else
            {
                Debug.Log("AIM TRANSFORM IS NULL");
            }
        }
        
        
    }
    //these obtain the mouse position in the world position for tracking on the map 
    public static Vector3 GetMouseWorldPositon()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }


    public virtual void UpdatePlayerAim()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            aimTransform = player.transform.Find("Aim");
            bulletSpawn = player.transform.Find("Aim");
        }
        
    }

}

