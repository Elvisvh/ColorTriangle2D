using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartColorGame : MonoBehaviour
{
    Color32 violet = new Color32(184, 22, 251, 255);
    Color32 red = new Color32(254, 58, 1, 255);
    Color32 blue = new Color32(22, 147, 251, 255);
    Color32 randomStartColor;

    public GameObject indicador;
    SpriteRenderer goColor;
    public Color indicadadorColor;

    // Start is called before the first frame update
    void Start()
    {
        goColor = indicador.GetComponent<SpriteRenderer>();
        RamdomColor();
        
    }


    void RamdomColor()
    {
        int randomInt;
        Color32[] colors = new Color32[3];
        colors[0] = red;
        colors[1] = violet;
        colors[2] = blue;

        randomInt = Random.Range(0, 3);
        randomStartColor = colors[randomInt];
        goColor.color = randomStartColor;
        Debug.Log("indicator: " + randomInt);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
