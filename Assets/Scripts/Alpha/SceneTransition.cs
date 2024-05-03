/*
 * Dylan Rothbauer
 * 02/21/24
 * 
 * Handles scene transtions on door
 * 
 * CHANGE LOG
 * Dylan - 02/21/24 - Added this new script for door functionality instead of player
 * Dylan - 02/27/24 - Added a bool to check if game objects with Enemy tag is dead (to avoid delegates)
 * Dylan/Colin - 03/04/24 - polished code and spacing added comments
 * Zach - 04/17/24 - Door does not open until a weapon is picked up
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToGoTo;
    private bool active = false;
    private Animator animator;
    private float delay = 1.0f;
    public GameObject sound;
    private bool isPlaying = false;
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        weapon = GameObject.FindGameObjectWithTag("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        // Checks for current enemies on scene
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && weaponPickup())
        {
            if (!weapon.GetComponent<BoxCollider2D>().enabled)
            {
                //active = true;
                if (!isPlaying)
                {
                    Instantiate(sound);
                    isPlaying = true;
                }
                animator.SetBool("active", true);
                Invoke("ActivateDoor", delay);
            }
        }
    }
    // Checks when player collides with door and enemies are dead
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active)
        {
            SceneManager.LoadScene(sceneToGoTo);
        }
    }

    private void ActivateDoor()
    {
        active = true;
        
    }

    public bool GetActive()
    {
        return active;
    }

    public bool weaponPickup()
    {
        return true;
    }
}
