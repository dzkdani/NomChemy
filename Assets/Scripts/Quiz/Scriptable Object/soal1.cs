﻿using UnityEngine;

[CreateAssetMenu(fileName = "nomorsoal", menuName = "Soal 1")]
public class soal1 : ScriptableObject
{
    public string tag;
    public string unsur1;
    public string unsur2;

    //special case
    [TextArea]
    public string unsur3;

    public int dapatBereaksi; 
    
    public string pilA, pilB, pilC, pilD, pilE;
    public int pilBenar;

}
