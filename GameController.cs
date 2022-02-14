using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    GameObject player;
    SpriteRenderer playerColor;
    Color32 violet = new Color32(184, 22, 251, 255);
    Color32 red = new Color32(254, 58, 1, 255);
    Color32 blue = new Color32(22, 147, 251, 255);
    public float salto;
    public float jump;
    Rigidbody2D rb;
    Transform playerParent;
    float positionPlayer;
    float gravity2D;

    public GameObject __mainCamera;
    Camera mainCamera;
    Vector3 sizeOfScreen;

    public static float __squareVelocity;
    float time;
    int seconds;

    public static int score;
    int scoreSave;
    float scoreFloat;
    public static int scoreToShow;
    public Text scoreText;

    Vector2 startPos;
    Vector2 direction;

    bool isRight;
    bool isLeft;

    bool isColored;

    Text prueba;

    AudioSource slidePlayer;
    AudioSource jumpAudio;
    AudioSource changeColorAudio;

    public GameObject texts_tuto;
    public bool instanciateAnim;
    public GameObject show_score_color;
    Animator animTextSore;
    public static bool inicioJuego;


  


    void Start()
    {
        animTextSore = show_score_color.GetComponent<Animator>();
        slidePlayer = GameObject.Find("switch3").GetComponent<AudioSource>();
        jumpAudio = GameObject.Find("jump").GetComponent<AudioSource>();
        changeColorAudio = GameObject.Find("ChangeColor").GetComponent<AudioSource>();

        prueba = GameObject.Find("prueba").GetComponent<Text>();
        Physics2D.gravity = new Vector2(0, -6.98f);

        positionPlayer = 0.2119329f;
        player = GameObject.FindGameObjectWithTag("Player");
        playerColor = player.GetComponent<SpriteRenderer>();
        rb = player.GetComponent<Rigidbody2D>();
        gravity2D = 6.98f;
        RandomColor();

        __mainCamera = GameObject.Find("MainCamera");
        mainCamera = __mainCamera.GetComponent<Camera>();
        __squareVelocity = -2f;

        scoreFloat = 0;
        score = 0;
        scoreSave = 0;
        scoreToShow = 0;

        isRight = false;
        isLeft = false;
        isColored = true;

        jump = 5f;

        inicioJuego = false;
        
    }

    void validateTextTuto()
    {
        if (texts_tuto == null)
        {
            instanciateAnim = true;
            inicioJuego = true;
        }
    }

    void instanciateAnimation()
    {
        validateTextTuto();
        if (instanciateAnim)
        {
            animTextSore.SetBool("inicio", true);
        }
    }

    void ScoreTextUI()
    {
        scoreToShow = score + scoreSave;
        scoreText.text = scoreToShow.ToString();
    }

    void TimeCalculator()
    {
        time += Time.deltaTime;
        //scoreFloat -= Time.deltaTime;
        scoreSave = (int)scoreFloat;
        seconds = (int)time;
        if(seconds > 5)
        {
            __squareVelocity -= 0.10f;
            time = 0;
        }

    }

#if UNITY_EDITOR
    void PayerMovement()
    {
        if (Input.GetMouseButtonDown(1) && CheckGround.isGround)
        {
            if(Physics2D.gravity.x == -gravity2D)
            {
                rb.velocity += Vector2.right * salto;
            }
            if (Physics2D.gravity.x == gravity2D)
            {
                rb.velocity += Vector2.left * salto;
            }
            jumpAudio.Play();

        }
       
        if (Input.GetKey(KeyCode.A) && CheckGround.isGround)
        {
            player.transform.localPosition = new Vector2(-positionPlayer, player.transform.localPosition.y);
            player.transform.localScale = new Vector2(-1, -1);
            Physics2D.gravity = new Vector2(gravity2D, 0);
            slidePlayer.Play();
        }
        if (Input.GetKey(KeyCode.D) && CheckGround.isGround)
        {
            player.transform.localPosition = new Vector2(positionPlayer, player.transform.localPosition.y);
            player.transform.localScale = new Vector2(1, 1);
            Physics2D.gravity = new Vector2(-gravity2D, 0);
            slidePlayer.Play();
        }
        
    }

    void ChangeColor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RandomColor();
        }
    }

#endif 

    void PlayerMovementTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    
                    if(direction.x < 0) //left
                    {
                        if(CheckGround.isGround && isLeft == true && direction.x < -200f)
                        {
                            rb.velocity += Vector2.left * jump;
                            jumpAudio.Play();
                        }
                        if (CheckGround.isGround && isLeft == false)
                        {
                            player.transform.localPosition = new Vector2(-positionPlayer, player.transform.localPosition.y);
                            player.transform.localScale = new Vector2(-1, -1);
                            Physics2D.gravity = new Vector2(gravity2D, 0);
                            slidePlayer.Play();
                            isLeft = true;
                            isRight = false;
                        }
                    }
                    if(direction.x > 0)//right
                    {
                        if (isRight && CheckGround.isGround && direction.x > 200f)
                        {
                            rb.velocity += Vector2.right * jump;
                            jumpAudio.Play();
                        }
                        if (CheckGround.isGround && isRight == false)
                        {
                            player.transform.localPosition = new Vector2(positionPlayer, player.transform.localPosition.y);
                            player.transform.localScale = new Vector2(1, 1);
                            Physics2D.gravity = new Vector2(-gravity2D, 0);
                            slidePlayer.Play();
                            isRight = true;
                            isLeft = false;
                            
                        }

                    }
                    isColored = false;
                    break;

                case TouchPhase.Stationary:
                    isColored = true;
         
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    if (isColored)
                    {
                        RandomColor();
                    }
                    break;
            }
            prueba.text = isColored.ToString();
        }
    }


    void RandomColor()
    {
        changeColorAudio.Play();
        if(playerColor.color == violet)
        {
            playerColor.color = red;
        }else if( playerColor.color == red)
        {
            playerColor.color = blue;
        }else if(playerColor.color == blue)
        {
            playerColor.color = violet;
        }
        else
        {
            playerColor.color = violet;
        }
        
    }
   void ScreenSize()
    {
        sizeOfScreen = new Vector3(0, mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y -0.5f, 0);
        Debug.Log("Size screen: " + sizeOfScreen.y);
        ScoreTextUI();
    }






    void Update()
    {
        PlayerMovementTouch();
        if (rb.velocity.x > jump || rb.velocity.x < -jump)
        {
            rb.velocity = new Vector2(0, 0);
        }
        instanciateAnimation();
#if UNITY_EDITOR
        ChangeColor();
        PayerMovement();
#endif
        ScreenSize();
        TimeCalculator();
        Debug.Log("Velocity: " + __squareVelocity);
        
    }
}
