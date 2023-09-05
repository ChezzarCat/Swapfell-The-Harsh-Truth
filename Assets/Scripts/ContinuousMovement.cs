using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Adjust the speed as needed
    public float lifetime = 3f; // Time in seconds before the object is destroyed
    public bool goesLeft = true;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        // Move the prefab to the left
        if (goesLeft)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Check if it's time to destroy the object
        if (Time.time - startTime >= lifetime)
        {
            Destroy(gameObject); // Destroy the object after the specified lifetime
        }
    }
}
