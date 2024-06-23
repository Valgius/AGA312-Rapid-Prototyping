using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformMove : MonoBehaviour
{
    public Transform[] points;  // Array to hold the points (positions) the platform will move between
    public float speed = 2.0f;  // Speed at which the platform moves between points

    private Transform currentTarget;  // Current target point for the platform to move towards

    void Start()
    {
        // Select a random initial target point from the array
        currentTarget = points[Random.Range(0, points.Length)];
    }

    void Update()
    {
        // Move the platform towards the current target point
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // Check if the platform has reached the current target point
        if (transform.position == currentTarget.position)
        {
            // Select a new random target point from the array (excluding the current one)
            Transform newTarget = currentTarget;
            while (newTarget == currentTarget)
            {
                newTarget = points[Random.Range(0, points.Length)];
            }
            currentTarget = newTarget;
        }
    }
}
