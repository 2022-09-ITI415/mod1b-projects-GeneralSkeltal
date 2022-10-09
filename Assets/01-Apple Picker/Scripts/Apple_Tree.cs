using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Tree : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDirection;

    public float secondsBetweenAppleDrop;

    void Start()
    {
        // Dropping apples every second   

        Invoke("DropApple", 2f);
    }

    void DropApple() 
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke( "DropApple", secondsBetweenAppleDrop );
    }

    void Update()
    {
        // basic movement

        Vector3 pos = transform.position;

        pos.x += speed * Time.deltaTime;

        transform.position = pos;

        //changing direction

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move ri
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move l
        } 
    }
    private void FixedUpdate()
    {
        // changing direction randomly is now t

        if(Random.value < chanceToChangeDirection)
        {
            speed *= -1; // change direction
        }
    }     
}
