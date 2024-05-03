/*
 * Dylan Rothbauer
 * 02/19/24
 * Standard PlayerController class that handles movement, collisions, etc.
 * 
 * CHANGE LOG
 * Dylan - 02/19/24 - Added onCollisionEnter2D function to get scene transitions working
 * Dylan - 02/21/24 - Refactored scene transtion to a door script in SceneTransition
 * Colin - 02/21/24 - added variables and some lines of code in the update for finding length between player and curser
 * Zach - 02/23/24 - Added restraints to player movement to prevent it from moving outside a certain range
 * Dylan - 02/27/24 - Added a destroy object in collider function to test scene transitions (needed a way to "kill" enemies)
 * Dylan - 02/28/24 - Changed Collider to include melee functionality in my scene
 * Dylan/Colin - 03/04/24 - polished code and spacing
 * Dylan - 03/05/24 - Added PlayerStats SerializedFeild to try ScriptableObjects
 * Colin - 04/02/24 - added more to the on collision for melee/range choice
 * Zach - 04/19/24 - Added sound effects
 */
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{    
    public float horizontalInput;
    public float verticalInput;

    [SerializeField]
    private PlayerStats playerStats; // Trying out ScriptableObjects

    private float damageToPlayer = 10.0f;
    private Animator movementAnimate;
    private SpriteRenderer render;
    private Weapon attackDrection;
    private SceneTransition transition;
    //private SceneTransition transition;

    private Vector2 moveDir;
    private Vector2 lastMoveDir;
    private Rigidbody2D rb;
    private float angle;

    public AudioSource src;
    public AudioClip hurt;
    public AudioClip pickUp;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        movementAnimate = GetComponent<Animator>(); 
        render = GetComponent<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
        transition = GetComponent<SceneTransition>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerStats.speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * playerStats.speed);
        HandleMovementAnimations();
        HandleAttackAnimation();
    }
        //void setAnimation(bool flip, int dInt, bool walking) {
        //    gameObject.GetComponent<SpriteRenderer>().flipX = flip;
        //    movementAnimate.SetInteger("Direction", dInt);
        //    movementAnimate.SetBool("isWalking", walking);
        //}
    private void HandleAttackAnimation()
    {
        //float attX = 0f, attY = 0f;        
        if(Input.GetMouseButton(0))
        {
            //attY = +1;
            //movementAnimate.SetBool("isAttacking", true);
            movementAnimate.SetTrigger("Attacking");
        }
        else
        {
            movementAnimate.ResetTrigger("Attacking");
        }
        //if (Input.GetMouseButton(0))
        //{
        //    attX = -1;
        //}
        //bool isIdle = attX == 0 && attY == 0;

        //if(isIdle)
        //{
        //    attX = 0f;
        //    attY = 0f;
        //    movementAnimate.SetBool("isAttacking", false);
        //}
        //else
        //{
        //    
        //    movementAnimate.SetFloat("Horizontal", attX);
        //    movementAnimate.SetFloat("Verticle", attY);
        //}
            
    }
    private void HandleMovementAnimations()
    {
        Vector3 mousePosition = Weapon.GetMouseWorldPositon();
        Vector3 aimDirection = (mousePosition - gameObject.transform.position).normalized;
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;  
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        moveDir=new Vector2 (moveX, moveY).normalized;

        bool isIdle= moveX==0 && moveY==0;
        if (isIdle)
        {
            //idle
            rb.velocity = Vector2.zero;
            movementAnimate.SetBool("isWalking", false);
        }
        else
        {
            //moving
            lastMoveDir = moveDir;
            rb.velocity = moveDir * playerStats.speed;
            movementAnimate.SetBool("isWalking", true);
        }
        movementAnimate.SetFloat("Horizontal", aimDirection.x);
        movementAnimate.SetFloat("Verticle", aimDirection.y);


    }

    // Testing collision for delagate scene transition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            // take damage
            playerStats.TakeDamage(damageToPlayer);
            src.clip = hurt;
            src.Play();

        } else if (collision.gameObject.CompareTag("Charm"))
        {
            src.clip = pickUp;
            src.Play();
            playerStats.EquipCharm(collision.gameObject.GetComponent<Charm>());
            //Destroy(collision.gameObject);
            
        }
        else if (collision.gameObject.CompareTag("Weapon"))
        {
            src.clip = pickUp;
            src.Play();
            Singleton.Instance.SetWeapon(collision.gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            arrow.SetActive(false);
            transition.weaponPickup();
        }

    }
}
