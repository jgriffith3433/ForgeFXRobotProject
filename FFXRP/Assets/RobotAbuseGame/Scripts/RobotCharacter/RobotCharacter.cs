using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCharacter : MonoBehaviour
{
    [SerializeField] private RobotIK m_RobotIK = null;

    [SerializeField] private float m_ResetRobotPinTime = 1f;

    private DetachableJoint[] m_DetachableJoints = null;

    private Transform[] m_ResetTransformList = null;
    private Vector3[] m_ResetTransformVectorList = null;
    private Quaternion[] m_ResetTransformQuatList = null;

    private void Awake()
    {
        m_DetachableJoints = GetComponentsInChildren<DetachableJoint>();
        m_ResetTransformList = GetComponentsInChildren<Transform>();
        m_ResetTransformVectorList  = new Vector3[m_ResetTransformList.Length];
        m_ResetTransformQuatList = new Quaternion[m_ResetTransformList.Length];
        for(var i = 0; i < m_ResetTransformList.Length; i++)
        {
            m_ResetTransformVectorList[i] = m_ResetTransformList[i].position;
            m_ResetTransformQuatList[i] = m_ResetTransformList[i].rotation;
        }
    }

    public void ResetRobot()
    {
        var oldPinWeight = m_RobotIK.PuppetMasterPinWeight;
        m_RobotIK.PuppetMasterPinWeight = 1f;
        foreach (var detachableJoint in m_DetachableJoints)
        {
            if (!detachableJoint.IsAttached)
            {
                detachableJoint.Attach();
            }
        }
        for (var i = 0; i < m_ResetTransformList.Length; i++)
        {
            m_ResetTransformList[i].position = m_ResetTransformVectorList[i];
            m_ResetTransformList[i].rotation = m_ResetTransformQuatList[i];
        }
        m_RobotIK.PuppetMasterPinWeight = oldPinWeight;
    }

    public void DestroyRobot()
    {
        foreach (var detachableJoint in m_DetachableJoints)
        {
            if (detachableJoint.IsAttached)
            {
                detachableJoint.Detach();
            }
        }
    }

}
