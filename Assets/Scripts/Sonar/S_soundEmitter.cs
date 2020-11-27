using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_soundEmitter : MonoBehaviour
{
    SimpleSonarShader_Object _sonar;

    public float radius;
    public List<Renderer> neighbours = new List<Renderer>();
    public Transform cosoParaTirarRaycast;

    [SerializeField]
    private float _delayTimer = 1f;

    [SerializeField]
    private float _impulseStrength = 10f;

    private float _elapseTime = 0;

    private float _distanceToTarget;

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
            this._sonar.StartSonarRing(this.transform.position, _impulseStrength / 10.0f, searchObjects());
        }
    }

    public List<Renderer> searchObjects()
    {
        neighbours.Clear();
        var near = Physics.OverlapSphere(transform.position, radius);

        RaycastHit hit;

        for (int i = 0; i < near.Length; i++)
        {
            if (near[i].GetComponent<SimpleSonarShader_Object>() == null)
            {
                continue;
            }
            if (Physics.Linecast(near[i].transform.position, cosoParaTirarRaycast.position, out hit))
            {
                if (hit.transform.tag == "enemy")
                {
                    neighbours.Add(near[i].GetComponent<Renderer>());
                }
            }
        }
        return neighbours;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
