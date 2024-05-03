/* Horizontal Damage Animator
 * Otto
 * Desc: General Purpose Animator for when something takes damage.
 * ---- CHANGELOG ----
 * Otto (20240417) Added modded code from the vertical float animator and a cycles counter.
 * Otto (20240417) Added a speed adjuster for speeding up the animation.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDamageAnimation : MonoBehaviour
{
    public int cycles = 5;
    public int speed = 3;
    public float timer = 1;
    public Color dmgColor = new Color(0/255,0/255,0/255);
    public float horizontalMovement = .01f;

    private int completedCycles = 0;
    private EnemyHealth damaged;

    void Start() {
        damaged = GetComponent<EnemyHealth>();
        damaged.takeDamage += VisualizeDamage;
        if (damaged != null) {
            damaged.TakeDamage(0);
        }
    }

    private void VisualizeDamage() {
        Debug.Log("Yay I activated!!!");
        float floaterVar = Mathf.Sin(timer * Mathf.PI) * horizontalMovement;
        transform.position += new Vector3(floaterVar, 0, 0);
        if (timer < 0 && completedCycles < cycles)
        {
            timer = 2;
            completedCycles += 1;
        }
        timer -= Time.deltaTime * speed;
    }
}
