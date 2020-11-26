using UnityEngine;
using System.Collections;

public class LineOfSight : MonoBehaviour
{
    public bool booleano;
    public GameObject target;
    public float viewAngle;
    public float viewDistance;
    public LayerMask wall;
    public LayerMask player;

    private Vector3 _dirToTarget;
    private float _angleToTarget;
    private float _distanceToTarget;
    public bool _targetInSight;

    void Update()
    {

        //Primero calculamos que cumpla con los requisitos de distancia y ángulo.
        //Es decir, que este dentro del campo de visión sin contar obstáculos.        

        _dirToTarget = target.transform.position - transform.position;

        _angleToTarget = Vector3.Angle(transform.forward, _dirToTarget);

        _distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (_angleToTarget <= viewAngle && _distanceToTarget <= viewDistance)
        {

            //Una vez que descartamos las primeras posibilidades, vamos a utilizar un raycast.            
            RaycastHit hit;
            bool obstaclesBetween = false;
            if (Physics.Raycast(transform.position, _dirToTarget, out hit, _distanceToTarget))
                if (hit.collider.gameObject.layer == wall)
                    obstaclesBetween = true; //En caso de colisionar contra una pared, esto se vuelve verdadero.


            //Si el raycast no colisionó contra ningún objeto informamos que lo tiene en el rango de visión            
            if (!obstaclesBetween)
                _targetInSight = true;
            else
                _targetInSight = false;
        }
        else //Si no se cumplieron las condiciones
            _targetInSight = false;
    }

    void OnDrawGizmos()
    {
        if (booleano)
        {

            if (_targetInSight)
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.transform.position);


            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, viewDistance);

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + (transform.forward * viewDistance));

            Vector3 rightLimit = Quaternion.AngleAxis(viewAngle, transform.up) * transform.forward;
            Gizmos.DrawLine(transform.position, transform.position + (rightLimit * viewDistance));

            Vector3 leftLimit = Quaternion.AngleAxis(-viewAngle, transform.up) * transform.forward;
            Gizmos.DrawLine(transform.position, transform.position + (leftLimit * viewDistance));
        }
    }
}

