using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> points;
    [SerializeField] int index;
    [SerializeField]Transform currPoint;
    Rigidbody rb;

    public float moveSpeed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currPoint = points[index];
    }

    private void Update()
    {
        //Check if arrived
        if (Vector3.Distance(transform.position , currPoint.position) < 0.2f)
        {
            //Arrive
            if (index == points.Count - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            currPoint = points[index];
        }

        transform.position = Vector3.MoveTowards(transform.position, currPoint.position, moveSpeed * Time.deltaTime);
    }

}
