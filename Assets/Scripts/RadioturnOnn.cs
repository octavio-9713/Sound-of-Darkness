using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioturnOnn : MonoBehaviour
{
    S_soundEmitter _se;
    public GameObject target;
    public float distance;
    public bool isPlayerNear;
    void Start()
    {
        _se = GetComponent<S_soundEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < distance)
        {
            _se.stop = false;
        }
        else _se.stop = true;
    }

}
