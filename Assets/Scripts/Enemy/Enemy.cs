using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public List<Transform> waypoints;
    public List<Transform> waypointsGone = new List<Transform>();
    public Transform currentWaypoint;
    public float distance;
    public float speed;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        Waypoint();
    }

    public void Waypoint()
    {
        //this if return true when is imposible to go to the waypoint
        if (!agent.hasPath)
        {
            print("no path");
            return;
        }
        if (waypoints.Count <= 0)
        {
            foreach (var item in waypointsGone)
            {
                waypoints.Add(item);
            }
            waypointsGone.Clear();
        }
        if (Vector3.Distance(transform.position, waypoints[0].position) < distance)
        {
            agent.destination = waypoints[0].position;
            Vector3 dir = waypoints[0].position - transform.position;
            waypointsGone.Add(waypoints[0]);
            waypoints.Remove(waypoints[0]);
        }
        else
        {
            agent.destination = waypoints[0].position;
        }
    }
    public void Chase()
    {
        //TODO Make the chase logic
        //idea if no path to the player or lost vision of this, just call "Waypoint()" and should return to make the patrol
    }
}
