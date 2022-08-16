using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private Animator anim;

    //this varible below will be used to flip the character
    private SpriteRenderer sr;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    //private string ENEMY_TAG = "Enemy";

    private string JUMPING_ANIM = "isJumping";

    ////private bool isJumping;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimaterPlayer();
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
        {
            //moves character by decimals from left to right side on the horizontal axis
            //starts at negative up to positive float numbers
            movementX = Input.GetAxisRaw("Horizontal");
            //Time.deltatime slows down the speed and also smooths out the player movement
            transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

        }

        void AnimaterPlayer()
    {
        //we are moving to the right side
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        //moving to the left side
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

        // to animate the jump state
        if (isGrounded == true)
        {
            anim.SetBool(JUMPING_ANIM, false);
        }
        else
        {
            anim.SetBool(JUMPING_ANIM, true);
        }
    }

    void PlayerJump()
        {
        // Input.GetButtonDown("Jump") <-- this is so that the default key or button on which ever device you are playing on
        //will actually make the charctet jump. It is universal in unity to set it up like this with "Jump" as a parameter
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            FindObjectOfType<AudioManager>().Play("Jump");
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
        {
       
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        }

  

} // class
