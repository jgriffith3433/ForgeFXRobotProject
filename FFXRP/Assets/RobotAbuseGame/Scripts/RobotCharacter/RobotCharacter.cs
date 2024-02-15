using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCharacter : MonoBehaviour
{
    [SerializeField] private RobotIK m_RobotIK = null;

    [SerializeField] private float m_ResetRobotPinTime = 1f;

    private DetachableJoint[] m_DetachableJoints = null;

    private void Awake()
    {
        m_DetachableJoints = GetComponentsInChildren<DetachableJoint>();
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
