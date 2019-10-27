using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class kunciSoal1 {

    private string elemen1, elemen2; //ganti image ato sprite, dsb entar
    private int jwbnBenar; //1 ya, 0 tidak

    public kunciSoal1(string _elemen1, string _elemen2, int _jwbnBenar) {
        elemen1 = _elemen1;
        elemen2 = _elemen2;
        jwbnBenar = _jwbnBenar;
    }
    public string getElemen1() { return elemen1; }
    public string getElemen2() { return elemen2; }
    public int getJwbn() { return jwbnBenar; }
}

public class kunciSoal2 {
    private string opsiA, opsiB, opsiC, opsiD, opsiE;
    private int opsiBenar;

    public kunciSoal2 (string _opsA, string _opsB, string _opsC, string _opsD, string _opsE, int _opsBnr) {
        opsiA = _opsA;
        opsiB = _opsB;
        opsiC = _opsC;
        opsiD = _opsD;
        opsiE = _opsE;
        opsiBenar = _opsBnr;
    }
    public int getOpsBnr() { return opsiBenar; }
    public string getOpsiA() { return opsiA; }
    public string getOpsiB() { return opsiB; }
    public string getOpsiC() { return opsiC; }
    public string getOpsiD() { return opsiD; }
    public string getOpsiE() { return opsiE; }
}

public class SoalManager : MonoBehaviour
{
    [SerializeField] private bool tempJwbn1, tempJwbn2;
    //nanti di jadikan satu
    [SerializeField] private int maxSoal1, maxSoal2;
    [SerializeField] private int currSoalindex = 0;

    private GameObject panelPenjelasan;
    private GameObject panelSoal, panelSoal1, panelSoal2;
    private const int triggerCount = 2;
    private const int initCount = 0;
    private const int nilaiSoal = 10;
    private bool isSoalDone = false;
    [SerializeField ]private int count;
    private ScoreManager skor;


     List<kunciSoal1> daftarSoal1 = new List<kunciSoal1>();
    public TextMeshProUGUI[] elemenText = new TextMeshProUGUI[2];
     List<kunciSoal2> daftarSoal2 = new List<kunciSoal2>();
     public Button[] opsi = new Button[5];

     
    // Start is called before the first frame update
    void Awake()
    {
        //uji coba list maybe ganti
        daftarSoal1.Add(new kunciSoal1("Na+", "Cl-", 1));
        daftarSoal1.Add(new kunciSoal1("Fa2+", "O2-", 0));
        //uji coba soal 2
        daftarSoal2.Add(new kunciSoal2("Natrium Klorin", "Natrium Klorida", "Natrium Klor", 
        "Natrium Diklorida", "Dinatrium Klorida", 2));
        daftarSoal2.Add(new kunciSoal2("nama1", "nama2", "nama3", "nama4", "nama5", 5));


        maxSoal1 = daftarSoal1.Count(); //set max soal1
        maxSoal2 = daftarSoal2.Count();

        skor = FindObjectOfType<ScoreManager>();
        panelSoal = GameObject.FindGameObjectWithTag("Panel Soal");
        panelSoal1 = GameObject.FindGameObjectWithTag("Panel Soal 1");
        panelSoal2 = GameObject.FindGameObjectWithTag("Panel Soal 2");        
        panelPenjelasan = GameObject.FindGameObjectWithTag("Panel Penjelasan");
        panelSoal.SetActive(false);
        panelPenjelasan.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        //display panel soal
        if (count == triggerCount) {

            //next ganti image or else
            elemenText[0].SetText(daftarSoal1.ElementAt(currSoalindex).getElemen1());
            elemenText[1].SetText(daftarSoal1.ElementAt(currSoalindex).getElemen2());
            //tes tok cok
            opsi[0].GetComponentInChildren<TextMeshProUGUI>().SetText(daftarSoal2.ElementAt(currSoalindex).getOpsiA());
            opsi[1].GetComponentInChildren<TextMeshProUGUI>().SetText(daftarSoal2.ElementAt(currSoalindex).getOpsiB());
            opsi[2].GetComponentInChildren<TextMeshProUGUI>().SetText(daftarSoal2.ElementAt(currSoalindex).getOpsiC());
            opsi[3].GetComponentInChildren<TextMeshProUGUI>().SetText(daftarSoal2.ElementAt(currSoalindex).getOpsiD());
            opsi[4].GetComponentInChildren<TextMeshProUGUI>().SetText(daftarSoal2.ElementAt(currSoalindex).getOpsiE());


            isSoalDone = false;
            StartCoroutine(invokeSoal());
            count = initCount;          
        }
        if (currSoalindex == maxSoal2) {
            Debug.Log("Level selesai");
        }
    }
    

    public void addCounterElen(int add) {
        count += add;
    }

    public bool soalDone() {
        return isSoalDone;
    }

    public void checkJwbnSoal1(int pil) {
        if (pil == daftarSoal1.ElementAt(currSoalindex).getJwbn()) {
            skor.addSkor(nilaiSoal);
            tempJwbn1 = true;
        } else {
            tempJwbn1 = false;
        }
        
        StartCoroutine(invokeNextSoal());
        
    }

    public void checkJwbnSoal2(int pil) {
        if (pil == daftarSoal2.ElementAt(currSoalindex).getOpsBnr()) {
            skor.addSkor(nilaiSoal);
            tempJwbn2 = true;
        } else { tempJwbn2 = false; }
        
        StartCoroutine(invokePenjelasan(tempJwbn1, tempJwbn2));
    }

    IEnumerator invokeSoal() {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        panelSoal.SetActive(true);
        panelSoal1.SetActive(true);
        panelSoal2.SetActive(false);
    }

    IEnumerator invokeNextSoal() {
        yield return new WaitForSecondsRealtime(0.75f);   
        panelSoal1.SetActive(false);
        panelSoal2.SetActive(true);
        
    }

    IEnumerator invokePenjelasan(bool jwbn1, bool jwbn2) {
        panelSoal.SetActive(false);
        panelPenjelasan.SetActive(true);


        if (jwbn1 && jwbn2) {
            Debug.Log("anda benar karena pintar");
            //load text penjelasam benar
        } else {
            Debug.Log("Anda salah karena goblok");
            //penjelasan salah
        }

        yield return new WaitForSecondsRealtime(10f);
        
        Time.timeScale = 1f;
        
        panelPenjelasan.SetActive(false);

        isSoalDone = true;
        tempJwbn1 = false;
        tempJwbn2 = false;
        currSoalindex += 1;

        //no need to remove klo masih dua elemen
        //daftarSoal1.RemoveAt(currSoalindex);
    }
}
