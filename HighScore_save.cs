using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore_save : MonoBehaviour
{
    int hg_save;
    public Text hs_Text;

    void Start()
    {
        hs_Text = GameObject.FindGameObjectWithTag("hs").GetComponent<Text>();
    }
    
    void Update()
    {
        hg_save = PlayerPrefs.GetInt("hs");
        hs_Text.text = hg_save.ToString();
        Debug.Log("SH: " + hg_save);
        Debug.Log("Game_SH: " + GameController.scoreToShow);

        if (GameController.scoreToShow > hg_save)
        {
            hg_save = GameController.scoreToShow;
            PlayerPrefs.SetInt("hs", hg_save);
        }
        Debug.Log("score xxx: " + GameController.scoreToShow);
        Debug.Log("Score guardado: " + hg_save);
    }
}
