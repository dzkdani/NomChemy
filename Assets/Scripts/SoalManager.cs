using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoalManager : MonoBehaviour
{
    private GameObject panelSoal;
    private int count;
    private const int triggerCount = 2;
    private const int initCount = 0;
    private static bool isSoal = false;

    // Start is called before the first frame update
    void Awake()
    {
        panelSoal = GameObject.FindGameObjectWithTag("Panel Soal");
        panelSoal.SetActive(false);
        //ngeload soal
        Debug.Log("Soal Ready");
    }
    // Update is called once per frame
    void Update()
    {
        if (count == triggerCount) {
            StartCoroutine(invokeSoal());
            count = initCount;
            //esp buat exit soal nanti hapus
        } else if (isSoal = false || Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 1f;
            panelSoal.SetActive(false);
        }
    }
    public void addCounterElen(int add) {
        count += add;
    }
    IEnumerator invokeSoal() {
        yield return new WaitForSeconds(0.75f);
        panelSoal.SetActive(true);
        Time.timeScale = 0f;
        isSoal = true;

    }
}
