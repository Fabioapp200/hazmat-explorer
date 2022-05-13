using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeController : MonoBehaviour
{
    [Header("Assignables")]
    public Animator animator;
    public GameObject player;
    public Rigidbody2D rb2d;
    public AudioSource audioSource;
    [Header("Slime status")]
    public float speed;
    public int health;
    public int healthReset;
    bool isGoingRight, canTakeDamage;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        rb2d.velocity = transform.right * speed;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "rightMarker" || other.name == "leftMarker")
        {
            Flip();
        }

        if (other.tag == "Player")
        {
            movementScript movementScript = player.GetComponent<movementScript>();
            movementScript.PlayerJump();
            animator.SetBool("Death", true);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerLifeController playerLifeController = player.GetComponent<playerLifeController>();
            playerLifeController.DecreaseLife();
        }
    }

    void Flip()
    {
        isGoingRight = !isGoingRight;

        transform.Rotate(0f, 180f, 0f);

    }
    public IEnumerator SlimeDeathSequence()
    {
        audioSource.Play();
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        killSlime();
    }
    public void killSlime()
    {
        health = 0;
    }
    public void increaseLife()
    {
        if (health < healthReset)
        {
            health += 1;
        }
    }

    public void decreaseLife(int damage)
    {
        if (health > 0)
        {
            health -= damage;

        }
    }
}
