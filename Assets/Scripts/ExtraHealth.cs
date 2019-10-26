using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealth : MonoBehaviour
{
    private HealthBarManager healthbar;
    private const int healAmount = 2;
    private readonly string plyr = "Player";
    private void Awake() {
        healthbar = FindObjectOfType<HealthBarManager>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == plyr) {
            if(healthbar) {
                healthbar.extraHealth(healAmount);
            }
            Destroy(gameObject);
        }
    }
}
