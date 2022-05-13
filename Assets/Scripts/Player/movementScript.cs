using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{

    Scene currentScene;
    bool ableToInput;

    //Arrowkey Movement
    public float speed;
    float currentSpeed;
    private float moveInput;


    //Jumping
    public float jumpForce;
    private bool canClimb, canJump, canDoubleJump, isGrounded, isOnVine;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;



    //Jump reseting
    private int extraJumps;
    public int extraJumpValue;


    //Sprite Flipping
    private bool facingRight;

    //animation controller
    public Animator animator;


    //footSteps Audio
    public AudioSource footstepControl;
    public AudioClip[] footsteps;
    public GameObject deathScreen;
    bool isWalking, isDead;


    public Rigidbody2D rb2D;


    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        rb2D = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
        facingRight = true;
        currentSpeed = speed;

        footstepControl = GetComponent<AudioSource>();
        footstepControl.clip = footsteps[0];
    }



    void Update()
    {
        //Detects ground under the character
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Resets extra jumps if the player is grounded
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        //Input blocker 
        if (currentScene.name == "Level_1")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerLifeController lifeController = player.GetComponent<playerLifeController>();
            ableToInput = lifeController.canGiveInput;
        }
        else
        {
            ableToInput = true;
        }


        //Jumping
        canJump = ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && extraJumps > 0) && !UIMenu.gameisPaused && ableToInput && !isOnVine;
        canDoubleJump = ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && extraJumps == 0 && isGrounded == true) && !UIMenu.gameisPaused && ableToInput;
        if (canJump)
        {
            PlayerJump();
        }
        else if (canDoubleJump)
        {
            StartCoroutine(PlayJumpSound());
            rb2D.velocity = Vector2.up * jumpForce;
        }
        //Vine climbing

        canClimb = (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && ableToInput;
        if (isOnVine && canClimb)
        {
            moveInput = Input.GetAxisRaw("Vertical");
            rb2D.velocity = new Vector2(rb2D.velocity.x, moveInput * currentSpeed);
        }

        //Jump Animation Control

        if (canJump)
        {
            animator.SetBool("isJumping", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player 1 Jump"))
        {
            animator.SetBool("isJumping", false);
        }


        //Check if the death screen is active 
        isDead = deathScreen.activeSelf;

        //ArrowKey Movement
        if (!UIMenu.gameisPaused && ableToInput)
        {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb2D.velocity = new Vector2(moveInput * currentSpeed, rb2D.velocity.y);
        }
        if (moveInput != 0)
        {
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                if (isGrounded && !isOnVine && !isDead)
                {
                    if(!isWalking)
                    StartCoroutine(PlayFootsteps());
                }
            }
            else
            {
                StopCoroutine(PlayFootsteps());
            }
        }
        else
        {
            isWalking = false;
        }

        if (facingRight == false && moveInput > 0 && !UIMenu.gameisPaused)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0 && !UIMenu.gameisPaused)
        {
            Flip();
        }

        //Walk/Idle Animation Control
        if ((rb2D.velocity.x > 0 || rb2D.velocity.x < 0))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    IEnumerator PlayFootsteps()
    {
        isWalking = true;
        float delay = 12;
        ChangeFootstep();
        footstepControl.Play();
        yield return new WaitForSeconds(footstepControl.clip.length + delay / 100);
        isWalking = false;
    }
    IEnumerator PlayJumpSound()
    {
        yield return new WaitForSeconds(0.1f);
        footstepControl.clip = footsteps[2];
        footstepControl.Play();
        yield return new WaitForSeconds(footstepControl.clip.length);
    }

    void ChangeFootstep()
    {
        if (footstepControl.clip == footsteps[1])
        {
            footstepControl.clip = footsteps[0];
        }
        else
        {
            footstepControl.clip = footsteps[1];
        }
    }

    public void PlayerJump()
    {
        StartCoroutine(PlayJumpSound());
        rb2D.velocity = Vector2.up * jumpForce;
        extraJumps--;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "vinhas1")
        {
            isOnVine = true;
            currentSpeed = speed * 0.75f;
            extraJumps = -1;
            rb2D.drag = 30;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "vinhas1")
        {
            isOnVine = false;
            currentSpeed = speed;
            rb2D.drag = 0;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

