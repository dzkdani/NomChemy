using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public HealthBarManager healthbar;
    private const int obstacleDmg = 1;
    private readonly string plyr = "Player";

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == plyr) {
            if (healthbar) {
                healthbar.onTakeDamage(obstacleDmg);
            }
        }
    }
}
