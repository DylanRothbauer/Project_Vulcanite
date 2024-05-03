/* Vertical Float Animation
 * Otto
 * Desc: Makes Gameobjects appear to float without additional issues.
 * ---- CHANGELOG ----
 * Staton Otto (2024/04/17) - Made the values public variables so they can be adjustable
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFloatingAnimation : MonoBehaviour
{
    public float timer = 1;
    public float verticalMovement = .005f;
    // Update is called once per frame
    void Update()
    {
        float floaterVar = Mathf.Sin(timer*Mathf.PI)* verticalMovement;
        transform.position += new Vector3(0,floaterVar,0);
        if (timer < 0) {
            timer = 2;
        }
        timer -= Time.deltaTime;
    }
}
