using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //standart
        List<string> jawaban = new List<string>();
        jawaban.Add("YA");
        jawaban.Add("TIDAK");
        //enumerable
        IEnumerable<string> pilJwbn = pilihanJawaban(); //declare pointer
        List<string> getPilihanJwbn = pilJwbn.ToList(); //set data
    }

    private IEnumerable<string> pilihanJawaban() 
    {
        yield return "YA";
        yield return "TIDAK";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
