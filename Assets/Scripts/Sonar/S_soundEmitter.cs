using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_soundEmitter : MonoBehaviour
{
    SimpleSonarShader_Object _sonar;
    
    public float _delayTimer = 1f;
    
    public float _impulseStrength = 10f;

    private void Start()
    {
        this._sonar = GetComponent<SimpleSonarShader_Object>();
        StartCoroutine("EmitPulseRutine");
    }

    IEnumerator EmitPulseRutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayTimer);
            _sonar.StartSonarRing(transform.position, _impulseStrength / 10.0f);
        }
    }
}
