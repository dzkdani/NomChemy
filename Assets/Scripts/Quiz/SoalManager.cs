using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SoalManager : MonoBehaviour
{
    [SerializeField] private bool tempJwbn1, tempJwbn2;
    //nanti di jadikan satu
    [SerializeField] private int maxSoal;
    [SerializeField] private int currSoalindex = 0;

    private GameObject panelPenjelasan;
    private GameObject panelSoal, panelSoal1, panelSoal2;
    private const int triggerCount = 2;
    private const int initCount = 0;
    private const int nilaiSoal = 10;
    private bool isSoalDone = false;
    [SerializeField ]private int count;
    private ScoreManager skor;
    public int currentlevel;


    public TextMeshProUGUI[] elemenText = new TextMeshProUGUI[2];
    public Button[] opsiButton = new Button[5];

    public List<soal1> kunciJwbnLvl1 = new List<soal1>();

     
    // Start is called before the first frame update
    void Awake()
    {
        maxSoal = kunciJwbnLvl1.Count();

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
            isSoalDone = false;
            StartCoroutine(invokeSoal());
            count = initCount;          
        }
        if (currSoalindex == maxSoal) {
            StartCoroutine(loadNextLevel(currentlevel + 1));
        }
    }
    

    public void addCounterElen(int add) {
        count += add;
    }

    public bool soalDone() {
        return isSoalDone;
    }

    public void checkJwbnSoal1(int pil) {
        if (pil == 1) {
            skor.addSkor(nilaiSoal);
            tempJwbn1 = true;
        } else { tempJwbn1 = false; }
        

        if (currentlevel == 1) { StartCoroutine(invokeNextSoal()); }
    }

    public void checkJwbnSoal2(int pil) {
        if (pil == kunciJwbnLvl1[currSoalindex].pilBenar) {
            skor.addSkor(nilaiSoal);
            tempJwbn2 = true;
        } else { tempJwbn2 = false; }
        
        StartCoroutine(invokePenjelasan(tempJwbn1, tempJwbn2));
    }

    IEnumerator loadNextLevel(int lvl) {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level " + lvl);
    }

    IEnumerator invokeSoal() {
        elemenText[0].SetText(kunciJwbnLvl1[currSoalindex].unsur1);
        elemenText[1].SetText(kunciJwbnLvl1[currSoalindex].unsur2);

        yield return new WaitForSeconds(1f);
        
        Time.timeScale = 0f;
        panelSoal.SetActive(true);
        panelSoal1.SetActive(true);
        panelSoal2.SetActive(false);
    }

    IEnumerator invokeNextSoal() {
        opsiButton[0].GetComponentInChildren<TextMeshProUGUI>().SetText(kunciJwbnLvl1[currSoalindex].pilA);
        opsiButton[1].GetComponentInChildren<TextMeshProUGUI>().SetText(kunciJwbnLvl1[currSoalindex].pilB);
        opsiButton[2].GetComponentInChildren<TextMeshProUGUI>().SetText(kunciJwbnLvl1[currSoalindex].pilC);
        opsiButton[3].GetComponentInChildren<TextMeshProUGUI>().SetText(kunciJwbnLvl1[currSoalindex].pilD);
        opsiButton[4].GetComponentInChildren<TextMeshProUGUI>().SetText(kunciJwbnLvl1[currSoalindex].pilE);
        
        yield return new WaitForSecondsRealtime(0.75f);  

        panelSoal1.SetActive(false);
        panelSoal2.SetActive(true);
        
    }

    IEnumerator invokePenjelasan(bool jwbn1, bool jwbn2) {
        panelSoal.SetActive(false);
        panelPenjelasan.SetActive(true);


        if (jwbn1 && jwbn2) {
            Debug.Log("anda benar karena pintar");
            panelPenjelasan.GetComponentInChildren<TextMeshProUGUI>().SetText("Anda Pintar Euy!!");
            //load text penjelasam benar
        } else {
            Debug.Log("Anda salah karena goblok");
            panelPenjelasan.GetComponentInChildren<TextMeshProUGUI>().SetText("Anda Goblo Euy!!");
            //penjelasan salah
        }

        yield return new WaitForSecondsRealtime(10f);
        
        Time.timeScale = 1f;
        
        panelPenjelasan.SetActive(false);

        isSoalDone = true;
        tempJwbn1 = false;
        tempJwbn2 = false;
        currSoalindex += 1;

    }
}
