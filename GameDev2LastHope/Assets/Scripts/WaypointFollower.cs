using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Array used to allow more complex waypoint setups
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f; 

    // Update is called once per frame
    private void Update()
    {
       if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
       {
            currentWaypointIndex += 1;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
       }
       transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
