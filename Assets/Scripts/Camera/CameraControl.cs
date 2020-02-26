using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;

    public Transform m_target;
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;
    public float zoomSpeed = 10;
    public float rotateSpeed = 1;

    private void Awake()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    private void Update()
    {
        // Scroll the camera in and out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 cameraPos = Camera.main.transform.localPosition;
        cameraPos.z += scroll * zoomSpeed;
        cameraPos.z = Mathf.Clamp(cameraPos.z, -30, -5);
        Camera.main.transform.localPosition = cameraPos;

        // Move the camera in right mouse drag
        if (Input.GetMouseButton(1))
        {
            Vector3 angles = transform.localEulerAngles
                + (Vector3.right * Input.GetAxis("Mouse Y")
                + Vector3.up * Input.GetAxis("Mouse X")) *rotateSpeed;

            angles.x = Mathf.Clamp(angles.x, 0, 80);

            transform.localEulerAngles = angles;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        m_DesiredPosition = m_target.position;
        transform.position = Vector3.SmoothDamp(transform.position,
                     m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }
}
