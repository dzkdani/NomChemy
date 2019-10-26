using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI skorText;
    [SerializeField]
    private int currentSkor;
    // Start is called before the first frame update
    void Awake()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //kondisi nambah skor, nanti ganti
        if(Input.GetButtonDown("Fire1")) {
            currentSkor += 10;
        }
        setSkor(currentSkor.ToString());
    }

    void setSkor(string score) {
        skorText.SetText(score);
    }
}
