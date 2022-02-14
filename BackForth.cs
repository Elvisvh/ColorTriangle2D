using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForth : MonoBehaviour
{
    private Vector3 moveTowardsPoint;
    public float speed;
    public Transform startPoint;
    public Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MovePlatafotma()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTowardsPoint, speed * Time.deltaTime);
        if (transform.position == endPoint.position)
        {
            moveTowardsPoint = startPoint.position;

        }
        if (transform.position == startPoint.position)
        {
            moveTowardsPoint = endPoint.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatafotma();
    }
}
