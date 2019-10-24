using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public HealthBarManager healthbar;
    [SerializeField]
    private int obstacleDmg = 15;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            if (healthbar) {
                healthbar.onTakeDamage(obstacleDmg);
            }
        }
    }
}
