using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElenmayerManager : MonoBehaviour
{
    private SoalManager soal;
    private ElenCounter elenUICounter;
    private readonly string plyr = "Player";
    private void Awake() {
        soal = FindObjectOfType<SoalManager>();
        elenUICounter  = FindObjectOfType<ElenCounter>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == plyr) {
            soal.addCounterElen(1);
            elenUICounter.addElenUI();
            Destroy(gameObject);
        }
    }    
}
