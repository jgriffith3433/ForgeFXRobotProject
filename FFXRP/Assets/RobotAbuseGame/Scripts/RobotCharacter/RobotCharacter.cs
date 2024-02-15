using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCharacter : MonoBehaviour
{
    [SerializeField] private RobotIK m_RobotIK = null;

    [SerializeField] private float m_ResetRobotPinTime = 1f;

    public void ResetRobot()
    {
        StartCoroutine(ResetRobotRoutine());
    }

    private IEnumerator ResetRobotRoutine()
    {
        var oldPinWeight = m_RobotIK.PuppetMasterPinWeight;
        m_RobotIK.PuppetMasterPinWeight = 1f;
        yield return new WaitForSeconds(m_ResetRobotPinTime);
        m_RobotIK.PuppetMasterPinWeight = oldPinWeight;
    }
}
