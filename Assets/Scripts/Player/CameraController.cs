using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform cam;
    [SerializeField] private float cameraDistance = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private LayerMask collisionLayer;
    private Vector2 _mouseInput;
    private float _currentRotationY = 0f;
    [SerializeField] private float minVerticalAngle = -45f;
    [SerializeField] private float maxVerticalAngle = 45f;

    private void LateUpdate()
    {
        _mouseInput.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        _mouseInput.y = Input.GetAxis("Mouse Y") * mouseSensitivity;
        playerBody.Rotate(Vector3.up, _mouseInput.x);
        _currentRotationY -= _mouseInput.y;
        _currentRotationY = Mathf.Clamp(_currentRotationY,minVerticalAngle,maxVerticalAngle);
        cam.localRotation = Quaternion.Euler(_currentRotationY, 0, 0);

        Vector3 desiredPosition = playerHead.position + cam.forward * -cameraDistance;
        Vector3 finalPosition = CheckCameraCollision(desiredPosition);

        cam.position = finalPosition;
    }

    private Vector3 CheckCameraCollision(Vector3 desiredPosition)
    {
        if (Physics.Linecast(playerHead.position, desiredPosition, out RaycastHit hit, collisionLayer))
        {
            return hit.point + hit.normal * 0.1f;
        }
        else
        {
            return desiredPosition;
        }
    }
}