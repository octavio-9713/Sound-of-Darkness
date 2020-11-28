using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_soundEmitter : MonoBehaviour
{
    SimpleSonarShader_Object _sonar;

    public float radius;
    public List<Renderer> neighbours = new List<Renderer>();
    public Transform cosoParaTirarRaycast;
    public bool stop;

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

            if (!stop) {
                this._sonar.StartSonarRing(this.transform.position, _impulseStrength / 10.0f, searchObjects());
            }
        }
    }

    public void EmitDoubleRing()
    {
        this._sonar.StartSonarRing(this.transform.position, (_impulseStrength * 2) / 10.0f, searchObjects());
    }

    public List<Renderer> searchObjects()
    {
        neighbours.Clear();
        Collider[] near = Physics.OverlapSphere(transform.position, radius);

        RaycastHit hit;

        for (int i = 0; i < near.Length; i++)
        {
            //print(near[i].name + "antes del getcomponent");
<<<<<<< Updated upstream
            if (near[i].GetComponent<SimpleSonarShader_Object>() == null || near[i].GetComponent<Renderer>() == null)
=======
            if (near[i].GetComponent<SimpleSonarShader_Object>() == null)
>>>>>>> Stashed changes
            {
                continue;
            }
           //print(near[i].name + "despues del getcomponent pero antes del linecast");
            if (Physics.Linecast(near[i].transform.position, cosoParaTirarRaycast.position, out hit))
            {
                //print(near[i].name + "despues del line cast pero antes del hit " + hit.transform.name);
                if (hit.transform.tag == "enemy")
                {
                    //print(near[i].name + "despues de todo");
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
