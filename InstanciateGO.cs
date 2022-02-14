using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateGO : MonoBehaviour
{
    public GameObject[] squaresGo;
    int selectNum;
    public float spawnTime;
    float counter;
    public float squareVelocity;
    

    int range_1, range_2;
    void Start()
    {
        SeachSquares();
        spawnTime = Random.Range(1,15);
        squareVelocity = 0.5f;
        
    }

    void SeachSquares()
    {
        squaresGo = GameObject.FindGameObjectsWithTag("squares");
    }
    void InstantiateSquare()
    {
        counter += Time.deltaTime;
        if(counter >= spawnTime)
        {
            selectNum = Random.Range(0, squaresGo.Length);
            GameObject movementSquare;
            movementSquare = Instantiate(squaresGo[selectNum], transform.position, Quaternion.identity);
            movementSquare.GetComponent<Rigidbody2D>().velocity = new Vector2(0, GameController.__squareVelocity);
            Destroy(movementSquare, 15f);
            spawnTime = Random.Range(range_1, range_2);
            counter = 0;
        }
        

        
    }
   
    void ReduceRange()
    {
        if(GameController.scoreToShow < 500)
        {
            range_1 = 2;
            range_2 = 6;
        }
        else if (GameController.scoreToShow > 500  && GameController.scoreToShow < 1000)
        {
            range_1 = 2;
            range_2 = 5;
        }
        else if (GameController.scoreToShow > 1000 && GameController.scoreToShow < 1500)
        {
            range_1 = 2;
            range_2 = 4;
        }
        else if (GameController.scoreToShow > 1500)
        {
            range_1 = 1;
            range_2 = 4;
        }
        Debug.Log("Range_1: " + range_1);
        Debug.Log("Range_2: " + range_2);
    }


    void asignSpeedSquares()
    {
        squareVelocity += GameController.__squareVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.inicioJuego)
        {
            InstantiateSquare();
            ReduceRange();
        }
        
       
    }
}
