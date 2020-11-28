using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(LineOfSight))]
public class Enemy : MonoBehaviour
{
    public List<Transform> waypoints;
    public List<Transform> waypointsGone = new List<Transform>();
    public Transform currentWaypoint;
    public float waypointDistance;
    public float killDistance;
    public float waypointSpeed;
    public float chaseSpeed;
    public VictoryDefeatManager vdm;
    NavMeshAgent _agent;
    LineOfSight _ofSight;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _ofSight = GetComponent<LineOfSight>();

    }
    void Update()
    {
        if (_ofSight._targetInSight)
        {
            Chase();
            _agent.speed = chaseSpeed;
        }
        else
        {
            Waypoint();
            _agent.speed = waypointSpeed;
        }
    }

    public void Waypoint()
    {
        if (_agent.isStopped)
        {
            _agent.isStopped = false;
        }
        if (waypoints.Count <= 0)
        {
            for (int i = waypointsGone.Count - 1; i >= 0; i--)
            {
                waypoints.Add(waypointsGone[i]);
            }
           
            waypointsGone.Clear();
        }
        if (Vector3.Distance(transform.position, waypoints[0].position) < waypointDistance)
        {
            _agent.destination = waypoints[0].position;
            Vector3 dir = waypoints[0].position - transform.position;
            waypointsGone.Add(waypoints[0]);
            waypoints.Remove(waypoints[0]);
        }
        else
        {
            _agent.destination = waypoints[0].position;
        }
    }
    public void Chase()
    {
        if (Vector3.Distance(transform.position, _ofSight.target.transform.position) < killDistance)
        {
            vdm.Gameover();
            _agent.isStopped = true;
        }
        else _agent.isStopped = false;
        _agent.destination = _ofSight.target.transform.position;
    }
}
