using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI skorText;
    [SerializeField]
    private int currentSkor;
    // Start is called before the first frame update
    void Awake()
    {
        skorText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //kondisi nambah skor
        if(Input.GetButtonDown("Fire1")) {
            currentSkor += 10;
        }
        setSkor(currentSkor.ToString());
    }

    void setSkor(string score) {
        skorText.SetText(score);
    }
}
