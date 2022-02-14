using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoySquareByPlayer : MonoBehaviour
{
    Color thisGameobjectColor;
    Color collisionColor;

    Color32 violet = new Color32(184, 22, 251, 255);
    Color32 red = new Color32(254, 58, 1, 255);
    Color32 blue = new Color32(22, 147, 251, 255);
    Color32 randomStartColor;

    AudioSource diedSound;
    AudioSource touchSound;

    public GameObject squareScore;
    SpriteRenderer indicadorColor;
    int score_50;

    private void Start()
    {
        squareScore = GameObject.Find("indicador");
        indicadorColor = squareScore.GetComponent<SpriteRenderer>();
        thisGameobjectColor = transform.gameObject.GetComponent<SpriteRenderer>().color;
        diedSound = GameObject.Find("died").GetComponent<AudioSource>();
        touchSound = GameObject.Find("touch").GetComponent<AudioSource>();
        
       
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            collisionColor = collision.gameObject.GetComponent<SpriteRenderer>().color;

            if(collisionColor == thisGameobjectColor)
            {
                touchSound.Play();
                if(thisGameobjectColor == indicadorColor.color)
                {
                    GameController.score += 50;
                }
                
                Destroy(this.gameObject);
            }
            else
            {
                diedSound.Play();
                SceneManager.LoadScene(0);
            }
            
        }
       
    }
}
