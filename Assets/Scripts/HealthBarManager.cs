using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Image healthbar;
    private float currentHealth;
    private const int maxHealth = 5;
    private const int minHealth = 0;
    private void Awake() {
        currentHealth = maxHealth;
    }
    public float getHealth() {
        return currentHealth;
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
