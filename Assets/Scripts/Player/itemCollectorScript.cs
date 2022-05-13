using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollectorScript : MonoBehaviour
{
    public GameObject item1, item2, item3, item4, item5, item6;
    public GameObject item1UI, item2UI, item3UI, item4UI, item5UI, item6UI;
    public bool item1Collected, item2Collected, item3Collected, item4Collected, item5Collected, item6Collected;
    [Header("Audio Source")]
    public AudioSource AudioSource;

    private void Start() {
        item6Collected = true;

        item1 = GameObject.FindGameObjectWithTag("item1");
        item2 = GameObject.FindGameObjectWithTag("item2");
        item3 = GameObject.FindGameObjectWithTag("item3");
        item4 = GameObject.FindGameObjectWithTag("item4");
        item5 = GameObject.FindGameObjectWithTag("item5");
        item6 = GameObject.FindGameObjectWithTag("Green_Portal_Back");
        
        item1UI = GameObject.FindGameObjectWithTag("item1UI");
        item2UI = GameObject.FindGameObjectWithTag("item2UI");
        item3UI = GameObject.FindGameObjectWithTag("item3UI");
        item4UI = GameObject.FindGameObjectWithTag("item4UI");
        item5UI = GameObject.FindGameObjectWithTag("item5UI");
    }

    void Update()
    {
        item1.SetActive(!item1Collected);
        item2.SetActive(!item2Collected);
        item3.SetActive(!item3Collected);
        item4.SetActive(!item4Collected);
        item5.SetActive(!item5Collected);
        item6.SetActive(!item6Collected);
        item1UI.SetActive(item1Collected);
        item2UI.SetActive(item2Collected);
        item3UI.SetActive(item3Collected);
        item4UI.SetActive(item4Collected);
        item5UI.SetActive(item5Collected);

        //When all the items are collected the last one appears
        if (item1Collected && item2Collected && item3Collected && item4Collected && item5Collected)
        {
            item6Collected = false;
        }
        else
        {
            item6Collected = true;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "item1" && !UIMenu.gameisPaused)
        {
            item1Collected = true;
            AudioSource.Play();
        }
        if (other.tag == "item2" && !UIMenu.gameisPaused)
        {
            item2Collected = true;
            AudioSource.Play();
        }
        if (other.tag == "item3" && !UIMenu.gameisPaused)
        {
            item3Collected = true;
            AudioSource.Play();
        }
        if (other.tag == "item4" && !UIMenu.gameisPaused)
        {
            item4Collected = true;
            AudioSource.Play();
        }
        if (other.tag == "item5" && !UIMenu.gameisPaused)
        {
            item5Collected = true;
            AudioSource.Play();
        }
    }

    public void ActivateAll()
    {
        item1Collected = true;
        item2Collected = true;
        item3Collected = true;
        item4Collected = true;
    }

    public void DeactivateAll()
    {
        item1Collected = false;
        item2Collected = false;
        item3Collected = false;
        item4Collected = false;
    }
}
