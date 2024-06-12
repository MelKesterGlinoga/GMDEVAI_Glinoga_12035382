using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSens = 3f;
    [SerializeField]
    GameObject playerCam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float CameraUpAndDownRotation = 0f;
    private float CurrentCameraUpAndDownRotation = 0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //calc movement velocity
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 _movementHorizontal = transform.right * xMovement;
        Vector3 _movementVertical = transform.forward * zMovement;

        //final vector
        Vector3 _movementVelocity = (_movementHorizontal + _movementVertical).normalized * speed;

        //apply movement
        Move(_movementVelocity);

        //calc rotation as 3D vector for turning
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _rotationVector = new Vector3(0, _yRotation, 0) * lookSens;

        //Apply rotation
        Rotate(_rotationVector);

        //calc look up and down
        float _cameraUpDownRotation = Input.GetAxis("Mouse Y") * lookSens;

        //Apply rotation
        RotateCamera(_cameraUpDownRotation);
    }

    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (playerCam != null)
        {
            CurrentCameraUpAndDownRotation -= CameraUpAndDownRotation;
            CurrentCameraUpAndDownRotation = Mathf.Clamp(CurrentCameraUpAndDownRotation, -85, 85);

            playerCam.transform.localEulerAngles = new Vector3(CurrentCameraUpAndDownRotation, 0, 0);
        }
    }

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }

    void RotateCamera(float cameraUpAndDownRotation)
    {
        CameraUpAndDownRotation = cameraUpAndDownRotation;
    }
}
