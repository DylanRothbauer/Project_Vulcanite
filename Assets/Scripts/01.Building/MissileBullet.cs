/*Staton Otto
 * 3/18/2024
 * Discription: Bullet targeting to attack the player or an enemy.
 *  (currently working on attacking the mouse cursor.) 
 * CHANGE LOG
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : MonoBehaviour
{
    public float speed = 5;
    public float maxRotation = .2f;
    private int debugVal = 0;
    public bool negativeAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //THE OBJECT IS NOT MOVING FOR SOME REASON??????
        transform.position += Vector3.left * Time.deltaTime* speed;
        Vector3 mousePosition = GetMouseWorldPositon();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        float bullAngle = transform.eulerAngles.z;
        float angleDiff = (angle - bullAngle)%180;

        if (angle <= 0) { negativeAngle = false; }
        else { negativeAngle = true; }
        Debug.Log("Angle=" + angle + "   bullAngle=" + bullAngle + "   Bool negativeAngle="+ negativeAngle + "  Angle Diff=" + angleDiff+"   debugVal=" + debugVal);
        if (!negativeAngle) {
            if (angleDiff+180 > maxRotation)
            {
                debugVal = 1;
                transform.eulerAngles += new Vector3(0, 0, (maxRotation));
            }
            else if (angleDiff < -maxRotation)
            {
                debugVal = 2;
                transform.eulerAngles += new Vector3(0, 0, (-maxRotation));
            }
            else
            {
                debugVal = 3;
                transform.eulerAngles += new Vector3(0, 0, (-angleDiff));
            }
        }
        //NEED TO FIX THE CODE IN THE IF STATEMENT
        if (negativeAngle)
        {
            if (angleDiff > -maxRotation)
            {
                debugVal = 4;
                transform.eulerAngles += new Vector3(0, 0, (maxRotation));
            }
            else if (angleDiff < maxRotation)
            {
                debugVal = 5;
                transform.eulerAngles += new Vector3(0, 0, (-maxRotation));
            }
            else
            {
                debugVal = 5;
                transform.eulerAngles += new Vector3(0, 0, (angleDiff));
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
}
