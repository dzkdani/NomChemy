using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Image healthbar;
    public float currentHealth;
    private const int maxHealth = 5;
    private const int minHealth = 0;
    private void Awake() {
        currentHealth = maxHealth;
    }
    
    public void onTakeDamage(int damage) {
        currentHealth -= damage; 
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    public void extraHealth(int heal) {
        currentHealth += heal;
        healthbar.fillAmount = currentHealth / maxHealth;
    }
}
