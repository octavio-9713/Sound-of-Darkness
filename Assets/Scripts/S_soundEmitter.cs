using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_soundEmitter : SimpleSonarShader_Object
{
    [SerializeField]
    private float _delayTimer = 1f;
    private float _elapseTime = 0;

    // Update is called once per frame
    void Update()
    {
        _elapseTime += Time.deltaTime;
        if (_elapseTime >= _delayTimer)
        {
            _elapseTime = _elapseTime % 1f;
            this.StartSonarRing(this.transform.position, 100 / 10.0f);
        }
    }
}
