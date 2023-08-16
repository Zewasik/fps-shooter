using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    public float maxHealth = 100f;
    public Image healthAmountImage;
    private SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        sceneController = GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        healthAmountImage.fillAmount = health / maxHealth;

        if (health <= 0 )
        {
            sceneController.LoadLevel("Game end");
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
