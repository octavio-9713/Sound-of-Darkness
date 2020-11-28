using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_sonar : MonoBehaviour
{
    SimpleSonarShader_Object _sonar;
    S_playerMovement _movement;

    public float cooldown = 1f;
    public float ringSize = 10f;
    float _elapseTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _sonar = GetComponent<SimpleSonarShader_Object>();
        _movement = GetComponent<S_playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        _elapseTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _elapseTime > cooldown && !_movement._moving)
        {
            _elapseTime = 0;
            _sonar.StartSonarRing(transform.position, ringSize / 10);
        }
    }
}
