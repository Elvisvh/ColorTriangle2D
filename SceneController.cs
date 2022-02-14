using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool click;
    AudioSource clickSound;

    private void Start()
    {
        click = false;
        clickSound = GameObject.Find("click2").GetComponent<AudioSource>();
    }
    public void LoadGame()
    {
        click = true;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        clickSound.Play();
    }

    public void araseAll()
    {
        PlayerPrefs.DeleteAll();
        GameController.scoreToShow = 0;
    }
   
}
