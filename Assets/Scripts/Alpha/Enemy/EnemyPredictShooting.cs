/*
 * Zachary Speckan
 * 03/06/24
 * Shooting a more accurate bullet at the player
 * 
 * projectile - The projectile object
 * projectileSpeed - The speed of the projectile
 * target - The player
 * 
 * targetingDistance - Max distance the enemy will shoot the player at
 * targetingTimer - How long the enemy will wait until firing another bullet
 * timer - How much time has passed since the last bullet was fired
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class EnemyPredictShooting : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;
    public Rigidbody2D target;

    public float targetingDistance = 25.0f;
    public float targetingTimer = 2.0f;
    private float timer;

    public AudioSource src;
    public AudioClip charge;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(projectile);
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the distance the player is from the enemy
        float distance = Vector2.Distance(transform.position, target.transform.position);
        //Debug.Log(distance);

        // Checks if the player is close enough
        if (distance < targetingDistance)
        {
            timer += Time.deltaTime;

            // Checks if enough time has passed
            if (timer > targetingTimer && gameObject.tag != "Boss")
            {
                timer = 0;
                src.clip = charge;
                src.Play();
                ShootToKill();
            }
        }
    }

    public void ShootToKill()
    {
        //Debug.Log("pre-instance; " + projectile + "; " +  transform.position);
        var instance = Instantiate(projectile, transform.position, quaternion.identity);
        var projectileVelocity = projectile.GetComponent<Rigidbody2D>().velocity;
        //Debug.Log("instance");
        if (InterceptionDirection(target.transform.position, transform.position, projectileVelocity, projectileSpeed, out var direction))
        {
            projectileVelocity = direction * projectileSpeed;
            //Debug.Log("FireIF!!");
        }
        else
        {
            projectileVelocity = (target.transform.position - transform.position).normalized * projectileSpeed;
            //Debug.Log("FireELSE!!");
        }

    }

    public bool InterceptionDirection(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result)
    {
        var aToB = b - a;
        var dC = aToB.magnitude;
        var alpha = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        var sA = vA.magnitude;
        var r = sA / sB;
        if (MyMath.SolveQuadratic(1 - r * r, 2 * r * dC * Mathf.Cos(alpha), -(dC * dC), out var root1, out var root2) == 0)
        {
            result = Vector2.zero;
            return false;
        }
        var dA = Mathf.Max(root1, root2);
        var t = dA / sB;
        var c = a + vA * t;
        result = (c - b).normalized;
        return true;
    }
}

public class MyMath
{
    public static int SolveQuadratic(float a, float b, float c, out float root1, out float root2)
    {
        var discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            root1 = Mathf.Infinity;
            root2 = -root1;
            return 0;
        }
        root1 = (-b + Mathf.Sqrt(discriminant)) / (2 * a);
        root2 = (-b - Mathf.Sqrt(discriminant)) / (2 * a);
        return discriminant > 0 ? 2 : 1;
    }
}
