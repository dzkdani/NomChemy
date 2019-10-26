using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skorText;
    [SerializeField] private int currentSkor = 0;
    // Start is called before the first frame update
    void Awake()
    {
        skorText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //kondisi nambah skor, nanti ganti
        if(Input.GetButtonDown("Fire1")) {
            currentSkor += 10;
        }
        
        setSkor("Score " + currentSkor.ToString());
    }

    void setSkor(string score) {
        skorText.SetText(score);
    }
}
