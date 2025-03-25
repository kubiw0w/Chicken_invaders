using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetMover : MonoBehaviour
{
    private Vector3 destination;
    public float speed = 5f; 
    public float amplitude = 1f; 
    public float frequency = 2f; 

    private Vector3 startPosition; 
    private float journeyLength;   
    private float startTime;       

    public void SetDestination(Vector3 targetPosition)
    {
        destination = targetPosition;
        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, destination);
        startTime = Time.time;
    }

    private void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "LEVEL1":
                StraightMovement();
                break;
            case "LEVEL2":
                SinusMovement();
                break;
            default:
                Debug.Log("Unknown Scene");
                break;
        }
    }

    private void SinusMovement()
    {
        // Calculate how far along the path the object has moved (linear interpolation)
        float elapsedTime = Time.time - startTime;
        float t = elapsedTime * speed / journeyLength;

        // Lerp the object along the straight-line path
        Vector3 straightLinePosition = Vector3.Lerp(startPosition, destination, t);

        // Add sinusoidal offset perpendicular to the movement path
        float sineOffset = Mathf.Sin(elapsedTime * frequency) * amplitude;

        // Example: Oscillate along the Y-axis (you can modify this based on your requirement)
        Vector3 sinusoidalPosition = straightLinePosition;
        sinusoidalPosition.y += sineOffset;

        // Update position
        transform.position = sinusoidalPosition;

        // Destroy the object once it reaches the destination
        if (t >= 1f) // When t reaches or exceeds 1
        {
            Destroy(gameObject);
        }
    }

    private void StraightMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}

