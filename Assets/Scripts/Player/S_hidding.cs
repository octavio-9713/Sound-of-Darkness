using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_hidding : MonoBehaviour
{
    public float hideDistance = 10f;
    public S_hideable hiddingTarget;

    public CharacterController controller;
    S_playerMovement movement;
    S_mouseLook look;
    public Camera fpsCamera;

    public float hideSpeed = 5f;
    public float hideRotSpeed = 3f;

    bool _isHidding = false;
    bool _hasToMoving = false;
    bool _hasToRestore = false;

    Vector3 _targetPos;
    Quaternion _targetRot;
    Vector3 _oldpos;
    Quaternion _oldRot;

    private void Start()
    {

        movement = GetComponent<S_playerMovement>();
        look = GetComponentInChildren<S_mouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (!_hasToMoving && !_hasToRestore))
        {
            if (_isHidding)
            {
                ExitHide();
            }

            else if (hiddingTarget != null)
            {
                Vector3 fromPtoH = (hiddingTarget.transform.position - this.transform.position).normalized;
                float dotProd = Vector3.Dot(fromPtoH, this.transform.forward);
                Debug.Log("Dot Product: " + dotProd);
                if (dotProd > 0.9 && Vector3.Distance(transform.position, hiddingTarget.transform.position) <= hideDistance)
                {
                    MoveToHide();
                }
            }
        }

        if(_hasToMoving)
        {
            Debug.Log("Has to move");
            MoveToPosition(_targetPos, _targetRot);
        }
        if (_hasToRestore)
        {
            Debug.Log("Has to restore");
            MoveToPosition(_oldpos, _oldRot);
        }
    }

    void MoveToPosition(Vector3 position, Quaternion rotation)
    {

        fpsCamera.transform.position = Vector3.MoveTowards(fpsCamera.transform.position, position, hideSpeed * Time.deltaTime);
        
        Quaternion rot = fpsCamera.transform.rotation;
        Quaternion nextRotation = Quaternion.Slerp(fpsCamera.transform.rotation, rotation, hideRotSpeed * Time.deltaTime);
        fpsCamera.transform.rotation = nextRotation;
         
        if (fpsCamera.transform.position == position)
        {
            _hasToMoving = false;
            _hasToRestore = false;
        }
    }

    void MoveToHide()
    {
        movement.DisableMovement();
        look.DisableLook();

        _oldpos = fpsCamera.transform.position;
        
        _oldRot = fpsCamera.transform.rotation;
        _targetPos = hiddingTarget.hidePosition.position;
        _targetRot = Quaternion.LookRotation(fpsCamera.transform.forward * (hiddingTarget.inverseHidding ? -1 : 1), fpsCamera.transform.up);
        _isHidding = true;
        _hasToMoving = true;
    }

    void ExitHide()
    {
        movement.EnableMovement();
        look.EnableLook();
        
        _isHidding = false;
        _hasToRestore = true;
    }
}
