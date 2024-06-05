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
        /*if (playerHealth == null)
        {
            Debug.LogError("PlayerScript reference is not assigned!");
            return;
        }
        if (healthBar == null)
        {
            Debug.LogError("HealthBar reference is not assigned!");
            return;
        }*/

        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
