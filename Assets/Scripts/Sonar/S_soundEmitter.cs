using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_soundEmitter : MonoBehaviour
{
    SimpleSonarShader_Object _sonar;

    [SerializeField]
    private float _delayTimer = 1f;

    [SerializeField]
    private float _impulseStrength = 10f;

    private float _elapseTime = 0;

    private void Start()
    {
        this._sonar = GetComponent<SimpleSonarShader_Object>();
    }

    // Update is called once per frame
    void Update()
    {
        _elapseTime += Time.deltaTime;
        if (_elapseTime >= _delayTimer)
        {
            _elapseTime = _elapseTime % 1f;
            this._sonar.StartSonarRing(this.transform.position, _impulseStrength / 10.0f);
        }
    }
}
