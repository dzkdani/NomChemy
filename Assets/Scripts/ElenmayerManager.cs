using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElenmayerManager : MonoBehaviour
{
    public SoalManager soal;
    // Start is called before the first frame update
    void Start()
    {
        //get nama elenmayer
    }

    // Update is called once per frame
    void Update()
    {
        //display nama di atas
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            soal.count += 1;
            Destroy(gameObject);
        }
    }
}
