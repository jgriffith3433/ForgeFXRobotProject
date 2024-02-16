using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableJoint : MonoBehaviour
{
    [SerializeField] private ConfigurableJoint m_Joint = null;
    [SerializeField] private MeshRenderer m_Renderer = null;
    [SerializeField] private Rigidbody m_Rigidbody = null;
    [SerializeField] private Color m_MouseOverColor = Color.red;
    [SerializeField] private float m_JointReattachDistance = .5f;

    private Transform m_JointParent = null;
    private Rigidbody m_ConnectedBody = null;
    private Color m_OriginalColor;
    private bool m_Hovering = false;
    private bool m_Clicked = false;
    private bool m_Dragging = false;
    private Vector3 m_PickupStartPosition;

    private ConfigurableJointMotion m_JointDataMotionX;
    private ConfigurableJointMotion m_JointDataMotionY;
    private ConfigurableJointMotion m_JointDataMotionZ;

    private ConfigurableJointMotion m_JointDataMotionAngularX;
    private ConfigurableJointMotion m_JointDataMotionAngularY;
    private ConfigurableJointMotion m_JointDataMotionAngularZ;

    private bool m_JointAutoConfigureConnectedAnchor = false;
    private Vector3 m_JointAnchor = Vector3.zero;
    private Vector3 m_JointConnectedAnchor = Vector3.zero;

    private void Awake()
    {
        m_OriginalColor = m_Renderer.material.color;
    }

    private void OnMouseEnter()
    {
        m_Hovering = true;
        m_Renderer.material.color = m_MouseOverColor;
    }

    private void OnMouseExit()
    {
        m_Hovering = false;
        m_Renderer.material.color = m_OriginalColor;
    }

    private void OnMouseDown()
    {
        m_Clicked = true;
        Pickup();
    }

    private void OnMouseUp()
    {
        Drop();

        m_Clicked = false;
        m_Dragging = false;
        m_Renderer.material.color = m_OriginalColor;
    }

    private void OnMouseDrag()
    {
        m_Dragging = true;
    }

    private void Update()
    {
        if (m_Dragging)
        {
            var screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(m_PickupStartPosition).z);
            var newWorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            transform.position = newWorldPosition;
            m_Rigidbody.velocity = Vector3.zero;
            m_Renderer.material.color = m_MouseOverColor;
        }
    }

    public void Attach()
    {
        LoadState();
    }

    private void LoadState()
    {
        transform.parent = m_JointParent;
        m_Joint.connectedBody = m_ConnectedBody;

        m_Joint.xMotion = m_JointDataMotionX;
        m_Joint.yMotion = m_JointDataMotionY;
        m_Joint.zMotion = m_JointDataMotionZ;

        m_Joint.angularXMotion = m_JointDataMotionAngularX;
        m_Joint.angularYMotion = m_JointDataMotionAngularY;
        m_Joint.angularZMotion = m_JointDataMotionAngularZ;

        m_Joint.anchor = m_JointAnchor;
        m_Joint.connectedAnchor = m_JointConnectedAnchor;
        m_Joint.autoConfigureConnectedAnchor = m_JointAutoConfigureConnectedAnchor;
    }

    public void Detach()
    {
        SaveState();
        m_PickupStartPosition = transform.position;
        transform.parent = null;
        m_Joint.connectedBody = null;

        m_Joint.xMotion = ConfigurableJointMotion.Free;
        m_Joint.yMotion = ConfigurableJointMotion.Free;
        m_Joint.zMotion = ConfigurableJointMotion.Free;

        m_Joint.angularXMotion = ConfigurableJointMotion.Free;
        m_Joint.angularYMotion = ConfigurableJointMotion.Free;
        m_Joint.angularZMotion = ConfigurableJointMotion.Free;

        m_Joint.anchor = Vector3.zero;
        m_Joint.connectedAnchor = Vector3.zero;
        m_Joint.autoConfigureConnectedAnchor = false;
    }

    private void SaveState()
    {
        m_JointParent = transform.parent;
        m_ConnectedBody = m_Joint.connectedBody;

        m_JointAnchor = m_Joint.anchor;
        m_JointConnectedAnchor = m_Joint.connectedAnchor;
        m_JointAutoConfigureConnectedAnchor = m_Joint.autoConfigureConnectedAnchor;

        m_JointDataMotionX = m_Joint.xMotion;
        m_JointDataMotionY = m_Joint.yMotion;
        m_JointDataMotionZ = m_Joint.zMotion;

        m_JointDataMotionAngularX = m_Joint.angularXMotion;
        m_JointDataMotionAngularY = m_Joint.angularYMotion;
        m_JointDataMotionAngularZ = m_Joint.angularZMotion;
    }

    private void Pickup()
    {
    }

    private void Drop()
    {
    }
}
