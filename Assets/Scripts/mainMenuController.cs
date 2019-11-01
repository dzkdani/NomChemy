using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
        [SerializeField] public List<GameObject> panel = new List<GameObject>();
        public static int unlockedLvl = 1;
        
    private void Awake() {
        turnOffOtherPanel(4); //only turn on main menu
    }

    void turnOffOtherPanel(int indexOn) {
        foreach (var item in panel)
         {
             item.SetActive(false);
         }
         panel[indexOn].SetActive(true);
    }
    public void onButtonPressed(int index) {
         turnOffOtherPanel(index);
    }

    public void onBackButton() {
        turnOffOtherPanel(4);
    }

    public void onPlayLevel (int lvl) {
        if (lvl <= unlockedLvl)
        {
            SceneManager.LoadScene("Level " + lvl);
        } else {
            Debug.Log("Level Terkunci");
        }
    }

    public void onBackToMenu() { SceneManager.LoadScene("Main Menu"); }

}
