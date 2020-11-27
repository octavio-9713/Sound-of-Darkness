using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_playerMovement : MonoBehaviour
{
    public CharacterController controller;

    float _initialHeight;

    private float _speed = 5f;

    [Header("Walking")]
    public float walkingSpeed = 2f;

    [Header("Walking Sonar Options")]
    public float walkingRingsize = 10f;
    public float walkingRingOffset = 3f;
    public float delayWalkingSonarTime = 1f;

    [Header("Crouching")]
    public float crouchSpeed = 2f;

    [Tooltip("Used to determine how low the player would go.")]
    public float crouchMultiplier = 0.3f;

    [Header("Crouching Sonar Options")]
    public float crouchingRingSize = 5f;
    public float crouchRingOffset = 2f;
    public float delayCrouchSonarTime = 1f;

    private float _gravity = -9.8f;

    [Header("Sonar Related")]
    public SimpleSonarShader_Object sonar;
    public Transform bottomEmitter;
    public List<Renderer> neighbours = new List<Renderer>();
    private float _ringOffset;
    private float _sonarImpulse = 0f;
    
    private float _delayTimer = 0.5f;
    private float _elapseTime = 0;

    Vector3 _velocity;
    Vector3 _moveDir;

    bool moving = false;

    public void Start()
    {
        _initialHeight = controller.height;
        _sonarImpulse = walkingRingsize;
        _ringOffset = walkingRingOffset;
        _speed = walkingSpeed;

        StartCoroutine("EmitPulseRutine");
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCrouch();
        MoveCharacter();
    }

    void CheckForCrouch()
    {
        float newHeight = this._initialHeight;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            newHeight = newHeight * crouchMultiplier;
            _speed = crouchSpeed;
            _sonarImpulse = crouchingRingSize;
            _ringOffset = crouchRingOffset;
            _delayTimer = delayCrouchSonarTime;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            newHeight = _initialHeight;
            _speed = walkingSpeed;
            _sonarImpulse = walkingRingsize;
            _ringOffset = walkingRingOffset;
            _delayTimer = delayWalkingSonarTime;
        }

        float lastHeight = controller.height;
        controller.height = Mathf.Lerp(controller.height, newHeight, 5.0f * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, transform.position.y * (controller.height - lastHeight) * 0.5f, transform.position.z);
    }

    void MoveCharacter()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
            moving = true;

        else
            moving = false;

        _moveDir = transform.right * x + transform.forward * z;

        controller.Move(_moveDir * _speed * Time.deltaTime);

        //TODO: Add Ground check (maybe not necesary after all...)
        _velocity.y += _gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime * Time.deltaTime);
    }

    IEnumerator EmitPulseRutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayTimer);
            if (moving)
            {
                Vector3 diference = _moveDir * _ringOffset;
                sonar.StartSonarRing(bottomEmitter.position + diference, _sonarImpulse / 10.0f,searchObjects());
            }
        }
    }
    public List<Renderer> searchObjects()
    {
        neighbours.Clear();
        var near = Physics.OverlapSphere(transform.position, 5);

        RaycastHit hit;

        for (int i = 0; i < near.Length; i++)
        {
            //print(near[i].name + "antes del getcomponent");
            if (near[i].GetComponent<SimpleSonarShader_Object>() == null)
            {
                continue;
            }
            //print(near[i].name + "despues del getcomponent pero antes del linecast");
            if (Physics.Linecast(near[i].transform.position, bottomEmitter.position, out hit))
            {
                //print(near[i].name + "despues del line cast pero antes del hit" + hit.transform.name);
                if (hit.transform.tag == "Player")
                {
                    //print(near[i].name + "despues de todo");
                    neighbours.Add(near[i].GetComponent<Renderer>());
                }
            }
        }
        return neighbours;
    }
}
