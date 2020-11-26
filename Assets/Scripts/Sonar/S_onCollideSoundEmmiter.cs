using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_onCollideSoundEmmiter : MonoBehaviour
{
    SimpleSonarShader_Object _sonar;

    private void Start()
    {
        this._sonar = GetComponent<SimpleSonarShader_Object>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        this._sonar.StartSonarRing(collision.contacts[0].point, collision.impulse.magnitude / 10.0f);
    }
}
