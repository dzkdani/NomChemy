using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class daftarSoal1 {

    private string elemen1; //ganti image ato sprite, dll entar
    private string elemen2; //ganti image ato sprite, dsb entar
    private int jwbnBenar; //1 ya, 0 tidak

    public daftarSoal1(string _elemen1, string _elemen2, int _jwbnBenar) {
        elemen1 = _elemen1;
        elemen2 = _elemen2;
        jwbnBenar = _jwbnBenar;
    }

    public string getElemen1() {
        return elemen1;
    }
    public string getElemen2() {
        return elemen2;
    }
    public int getJwbn() {
        return jwbnBenar;
    }

}
public class SoalManager : MonoBehaviour
{
    [SerializeField] private int maxSoal1 = 2;
    [SerializeField] private int currSoal1index = 0;
    [SerializeField] private TextMeshProUGUI ele1;
    [SerializeField] private TextMeshProUGUI ele2;

    private GameObject panelSoal;
    private int count;
    private const int triggerCount = 2;
    private const int initCount = 0;
    private static bool isSoal = false;


     List<daftarSoal1> soal1 = new List<daftarSoal1>();
    // Start is called before the first frame update
    void Awake()
    {
        //uji coba list maybe ganti
        soal1.Add(new daftarSoal1("Fa2+", "O2-", 0));
        soal1.Add(new daftarSoal1("Na+", "Cl-", 1));


        panelSoal = GameObject.FindGameObjectWithTag("Panel Soal");
        panelSoal.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        //display panel soal
        if (count == triggerCount) {
         
            //next ganti image or else
            ele1.SetText(soal1[currSoal1index].getElemen1());
            ele2.SetText(soal1[currSoal1index].getElemen2());
         
         
            StartCoroutine(invokeSoal());
            count = initCount;
            
        }
    }
    public void addCounterElen(int add) {
        count += add;
    }

    public void checkJwbn(int pil) {
        if (pil == soal1[currSoal1index].getJwbn()) {
            Debug.Log("Benar!");
            //invoke penjelasan
        } else {
            Debug.Log("Salah!");
            //invoke penjelasan
        }
        Time.timeScale = 1f;
        panelSoal.SetActive(false);
        currSoal1index += 1;
        soal1.RemoveAt(currSoal1index);
    }

    IEnumerator invokeSoal() {
        
        yield return new WaitForSeconds(0.75f);
        panelSoal.SetActive(true);
        Time.timeScale = 0f;
        isSoal = true;
    }
}
