/* Staton Otto
 * 03/04/2024 dd/mm/yyyy
 * Created a new range/melee attack script for the beta release.
 * This is because we were having massive issues with our current scripts
 * to handle range and melee attack instantiation and attacks.
 * 
 * CHANGE LOG
 * dd/mm/yyyy - discription of changes
 * ---------------------------------------------
 * 
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttackScript : MonoBehaviour
{
    //object that will be shot
    public GameObject attackObject;
    //transform for the positioning and rotation of the shot
    private Transform aimTransform;
    //variable timer value
    public float timer =0;
    //for setting the time between shots
    public float timeBetweenShots = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        aimTransform = attackObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //checks for mouse click and whether the timer has reset
        if (Input.GetMouseButton(0) && timer <= 0) {
            //sets the timer to prevent repeated/continuous shots
            timer = timeBetweenShots;
            //world mouse position
            Vector3 mousePosition = GetMouseWorldPositon();
            // direction of the aim and the subsiquent transform.position
            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            // angle of the Z rotation
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            // transform.rotation of the angle rotation
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
            Vector3 freshPosition = transform.position + aimDirection*1.2f;
            //instantiates an attack object away from the player with the correct rotation.
            Instantiate(attackObject, freshPosition, aimTransform.rotation);
        }
        //Timer decreasing function for limiting the shots per second
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
    }


    //Needed to obtain the mouse position from the screen and world position
    // (without these functions we cannot pull the mouse position).
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
}
