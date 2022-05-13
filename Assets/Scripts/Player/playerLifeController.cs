using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLifeController : MonoBehaviour
{
    bool canTakeDamage = true;
    public float damageDelay;
    public int playerLife;
    public bool canGiveInput;
    public int respawnDelay;
    public int playerMaxLife;
    Renderer playerRenderer;
    public GameObject deathScreen;
    AudioSource audioSource;
    public AudioClip damageSFX, deathSFX;
    private void Start()
    {
        playerLife = playerMaxLife;
        canGiveInput = true;
        playerRenderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (playerLife <= 0 && playerRenderer.enabled)
        {
            KillPlayer();
        }
    }
    /* #region  Increase/Decrease total or max player life */
    public void resetLife()
    {
        playerLife = playerMaxLife;
    }
    public void IncreaseLife()
    {
        playerLife++;
    }
    public void DecreaseLife()
    {
        if (canTakeDamage == true)
        {
            playerLife--;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            audioSource = player.GetComponent<AudioSource>();
            audioSource.clip = damageSFX;
            audioSource.Play();
        }
        StartCoroutine(waitTotakeDamage());

    }
    public void IncreaseMaxLife()
    {
        playerMaxLife++;
    }
    public void DecreaseMaxLife()
    {
        playerMaxLife--;
    }
    /* #endregion */

    public void KillPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        audioSource.clip = deathSFX;
        audioSource.Play();
        StartCoroutine(WaitToRespawn());
    }
    IEnumerator WaitToRespawn()
    {
        playerRenderer = GetComponent<Renderer>();

        //Reference to the checkpointAndRespawn script
        canGiveInput = false;
        playerRenderer.enabled = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject camera = GameObject.FindGameObjectWithTag("camera");
        deathScreen.SetActive(true);
        camera.GetComponent<cameraControlScript>().enabled = false;
        checkpointAndRespawn checkAndRespawn = player.GetComponent<checkpointAndRespawn>();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        playerLife = playerMaxLife;
        deathScreen.SetActive(false);
        camera.GetComponent<cameraControlScript>().enabled = true;
        player.transform.position = checkAndRespawn.currentCheckpoint;
        playerRenderer.enabled = true;
        canGiveInput = true;
    }
    IEnumerator waitTotakeDamage()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageDelay);
        canTakeDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "killer1")
        {
            DecreaseLife();
        }
        if (other.gameObject.tag == "killer2")
        {
            DecreaseLife();
        }
        if (other.gameObject.tag == "acidWater1")
        {
            KillPlayer();
        }
    }

}
