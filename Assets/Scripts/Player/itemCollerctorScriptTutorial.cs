using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollerctorScriptTutorial : MonoBehaviour
{
    public GameObject[] items = new GameObject[4];
    public bool[] itemsCollected = new bool[3];
    private void Start()
    {
        items[0] = GameObject.FindGameObjectWithTag("item1");
        items[1] = GameObject.FindGameObjectWithTag("item2");
        items[2] = GameObject.FindGameObjectWithTag("item3");
        items[3] = GameObject.FindGameObjectWithTag("Green_Portal_Menu_1");

        items[3].SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < 3; i++)
        {
            if (other.tag == items[i].tag)
            {
                itemsCollected[i] = true;
                if (itemsCollected[i])
                {
                    items[i].SetActive(false);
                }
            }
        }
    }
    private void Update()
    {
        if (itemsCollected[0] && itemsCollected[1] && itemsCollected[2])
        {
            items[3].SetActive(true);
        }
    }
}
