using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoalManager : MonoBehaviour
{
    private const int triggerCount = 2;
    private const int initCount = 0;
    public int count;
    // Start is called before the first frame update
    void Awake()
    {
        //list soal
        Debug.Log("Soal Ready");
    }

    // Update is called once per frame
    void Update()
    {
        if (count == triggerCount) {
            Debug.Log("Manggil Soal");
            invokeSoal();
            count = initCount;
        }
    }

    void invokeSoal() {
        Debug.Log("Soal terpanggil");
    }
}
