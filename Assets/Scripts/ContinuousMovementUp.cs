using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMovementUp : MonoBehaviour
{
     public float moveSpeed = 1f; // Adjust the speed as needed
    public float lifetime = 3f; // Time in seconds before the object is destroyed
    public bool goesUp = true;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        // Move the prefab to the left
        if (goesUp)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        // Check if it's time to destroy the object
        if (Time.time - startTime >= lifetime)
        {
            Destroy(gameObject); // Destroy the object after the specified lifetime
        }
    }
}
