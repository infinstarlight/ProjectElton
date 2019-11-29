using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class MovingPlatform : MonoBehaviour
{
      // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private Rigidbody rb;
    public float MovementSpeed = 0;
//    private bool bChangeDirection = false;
    public float DistanceMaximum = 0.0f;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();    
    }
  
    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        float dist = Vector3.Distance(endMarker.position,transform.position);
        if(dist >= DistanceMaximum)
        {
            transform.position = Vector3.Lerp(endMarker.position,startMarker.position,fractionOfJourney);
        }
    }
}
