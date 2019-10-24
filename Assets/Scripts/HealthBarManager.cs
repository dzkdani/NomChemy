using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Image healthbar;
    [SerializeField]
    private float currentHealth;
    private float maxHealth = 100f;

    public void onTakeDamage(int damage) {
        currentHealth -= damage; 
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    public void extraHealth(int heal) {
        currentHealth += heal;
        healthbar.fillAmount = currentHealth / maxHealth;
    }
}
