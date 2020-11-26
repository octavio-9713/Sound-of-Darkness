using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_mouseLook : MonoBehaviour
{
    public Transform playerBody;

    [SerializeField]
    private float _mouseSensitivity = 100f;

    float _yRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Add joystick support
        float mouseX = Input.GetAxis("Mouse X") * this._mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * this._mouseSensitivity * Time.deltaTime;

        _yRotation -= mouseY;
        _yRotation = Mathf.Clamp(_yRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
