using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaScript : MonoBehaviour
{
    public Slider healthBar;
    public PlayerScript playerHealth;

    private void Start()
    {

        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }

    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}
