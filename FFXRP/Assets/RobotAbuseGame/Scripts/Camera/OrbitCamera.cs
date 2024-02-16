using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform m_OrbitTarget = null;
    [SerializeField] private float m_ZoomDistance = 5f;
    [SerializeField] private float m_RotationSensitivity = 100f;

    private float m_CamRotationX = 0f;
    private float m_CamRotationY = 0f;

    private float m_CamRotationXInput = 0f;
    private float m_CamRotationYInput = 0f;

    private void Update()
    {
        m_CamRotationX += (m_CamRotationXInput - Input.GetAxis("Vertical")) * m_RotationSensitivity * Time.deltaTime;
        m_CamRotationY += (m_CamRotationYInput - Input.GetAxis("Horizontal")) * m_RotationSensitivity * Time.deltaTime;


        if (m_CamRotationX > 90f)
        {
            m_CamRotationX = 90f;
        }
        else if (m_CamRotationX < -90f)
        {
            m_CamRotationX = -90f;
        }

        transform.position = m_OrbitTarget.position + Quaternion.Euler(m_CamRotationX, m_CamRotationY, 0f) * (m_ZoomDistance * -Vector3.back);
        transform.LookAt(m_OrbitTarget.position, Vector3.up);
    }

    public void SetRotationDirection(Vector2 direction)
    {
        m_CamRotationXInput = direction.x;
        m_CamRotationYInput = direction.y;
    }

}
