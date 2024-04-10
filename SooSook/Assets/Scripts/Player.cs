using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] HpSlider hpSlider;

    private void Awake()
    {
        hpSlider = GetComponentInChildren<HpSlider>();
    }

    void Start()
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
        }
    }
}
