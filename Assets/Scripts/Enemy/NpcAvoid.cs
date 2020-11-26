using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAvoid : MonoBehaviour
{
    public Transform target;
    Enemy _e;
    public LayerMask obstaclesLayer;
    public float radious;
    Transform _obs;
    public float speed;
    public float rotSpeed;
    public float avoidWeight;
    void Start()
    {
        _e = GetComponent<Enemy>();
    }


    void Update()
    {
        if (_e.currentWaypoint != null)
        {
            GetObstacle();
            Vector3 dir = (_e.currentWaypoint.position - transform.position).normalized;
            if (_obs)
            {
                dir += (transform.position - _obs.position).normalized * avoidWeight;
                print("entre");
            }
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * rotSpeed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void GetObstacle()
    {
        _obs = null;
        var obstacles = Physics.OverlapSphere(transform.position, radious, obstaclesLayer);
        print(obstacles.Length);
        if (obstacles.Length > 0)
        {
            foreach (var item in obstacles)
            {
                if (!_obs)
                    _obs = item.transform;
                else if (Vector3.Distance(item.transform.position, transform.position) < Vector3.Distance(_obs.position, transform.position))
                    _obs = item.transform;
            }
        }
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}
