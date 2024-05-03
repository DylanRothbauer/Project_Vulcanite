/* Staton Otto
 * 03/04/2024 dd/mm/yyyy
 * Created a new bullet that calculates its trajectory based off of its rotation for the player
 * this will help in the future for other objects we would like to add since this can be used
 * as a base class for other types of attacks.
 * 
 * CHANGE LOG
 * dd/mm/yyyy - discription of changes
 * ---------------------------------------------
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerBulletAttack : MonoBehaviour
{
    //speed control variable
    public float bulletSpeed = 10;
    //lifetime variable
    private float life = 5;
    //private x and y normalized position values
    private float xNorm;
    private float yNorm;
    
    // Start is called before the first frame update
    void Awake()
    {
        //pulls the degree of rotation
        float deg =gameObject.transform.eulerAngles.z;
        //converts it to radians
        float rad= deg*Mathf.PI / 180;
        //calculates the normals for x and y positions
        xNorm = Mathf.Cos(rad);
        yNorm = Mathf.Sin(rad);
    }

    // Update is called once per frame
    void Update()
    {
        //moves the object based on the normals calculated from the rotation
        gameObject.transform.position += new Vector3(xNorm,yNorm,0)*(bulletSpeed * Time.deltaTime);
        life -= Time.deltaTime;
        //kills the object after a certain ammount of time.
        if (life <= 0) {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
