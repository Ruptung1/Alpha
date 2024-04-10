using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] HpSlider hpSlider;

    PlayerMovementCOM playerMovementCOM;

    private void Awake()
    {
        hpSlider = GetComponentInChildren<HpSlider>(); 
    }

    private void Start()
    {
        health = maxHealth;       
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        hpSlider.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
            playerMovementCOM.RestisMoving();
        }
    }
}
