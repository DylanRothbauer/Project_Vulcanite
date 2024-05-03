using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniPlaEneController : MonoBehaviour
{
    Rigidbody2D myRB;  //This Rigid body 2D applies Physics (gravity, mass, drag) to the game object
    SpriteRenderer myRenderer;  //Sprite Renderer displays the sprite
    Animator myAnim;  //Animator changes between the sprite animation states

    //set animation parameters - TYPE these in the Animator paramaters as shown here
    bool facingRight = true;
    bool facingUp = false;
    bool isMoving = false;
    public float maxSpeed;


    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");  // is there controller (or keyboard arrow) on the X axis (Left/right)?
        float moveY = Input.GetAxisRaw("Vertical");    // is there controller (or keyboard arrow) on the Y axis (Up / down) ?


        if (moveX > 0 && !facingRight)
            Flip();
        else if (moveX < 0 && facingRight)
            Flip();

        if (moveY > 0 && !facingUp)
            FlipY();
        else if (moveY < 0 && facingUp)
            FlipY();




        myRB.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);

        if (Mathf.Abs(moveY) > 0 || Mathf.Abs(moveX) > 0)
        {
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }

        myAnim.SetBool("Moving", isMoving);
    }

    void Flip()
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }
    void FlipY()
    {
        facingUp = !facingUp;
        myAnim.SetBool("FacingBack", facingUp);

    }
}
