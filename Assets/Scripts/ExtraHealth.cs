using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHealth : MonoBehaviour
{
    public HealthBarManager healthbar;
    [SerializeField]
    private int healAmount = 30;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            if(healthbar) {
                healthbar.extraHealth(healAmount);
            }
            Destroy(gameObject);
        }
    }
}
