using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float maxHealth = 100f;
    public Image healthAmountImage;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        healthAmountImage.fillAmount = health / maxHealth;

        if (health == 0 )
        {
            Debug.Log("you are ded");
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }

    public void GetHeal(float healAmount)
    {
        health += healAmount;
    }
}
