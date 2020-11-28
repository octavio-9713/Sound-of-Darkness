using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioturnOnn : MonoBehaviour
{
    S_soundEmitter _se;
    AudioSource _as;
    public GameObject target;
    public float distance;
    public bool isPlayerNear;

    private bool _startSound = false;
    void Start()
    {
        _se = GetComponent<S_soundEmitter>();
        _as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < distance)
        {
            _se.stop = false;
            if (!_startSound)
            {
                _startSound = true;
                _as.Play();
            }
        }
        else
        {
            _se.stop = true;
            _startSound = false;
            _as.Stop();
        }
    }

}
