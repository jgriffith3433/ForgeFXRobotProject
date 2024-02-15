using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotIK : MonoBehaviour
{
    [SerializeField] private PuppetMaster m_PuppetMaster = null;

    public float PuppetMasterPinWeight
    {
        get
        {
            return m_PuppetMaster.pinWeight;

        }
        set
        {
            m_PuppetMaster.pinWeight = value;
        }
    }
}
