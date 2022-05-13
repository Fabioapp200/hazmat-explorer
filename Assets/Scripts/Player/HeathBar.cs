using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Slider slider;

    public void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerLifeController lifeController = player.GetComponent<playerLifeController>();
        slider.value = lifeController.playerLife;
        slider.maxValue = lifeController.playerMaxLife;
    }

    public void setMaxHeath(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void sethHealth(int health)
    {
        slider.value = health;
    }
}
