using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private RobotCharacter m_RobotCharacter = null;
    [SerializeField] private OrbitCamera m_OrbitCamera = null;
    [SerializeField] private UI m_UI = null;
    [SerializeField] private DetachableJoint m_LeftRobotArm = null;
    [SerializeField] private DetachableJoint m_RightRobotArm = null;

    private void OnEnable()
    {
        m_LeftRobotArm.OnAttach.AddListener(OnLeftArmAttached);
        m_LeftRobotArm.OnDetach.AddListener(OnLeftArmDetached);
        m_RightRobotArm.OnAttach.AddListener(OnRightArmAttached);
        m_RightRobotArm.OnDetach.AddListener(OnRightArmDetached);
    }

    private void OnDisable()
    {
        m_LeftRobotArm.OnAttach.RemoveListener(OnLeftArmAttached);
        m_LeftRobotArm.OnDetach.RemoveListener(OnLeftArmDetached);
        m_RightRobotArm.OnAttach.RemoveListener(OnRightArmAttached);
        m_RightRobotArm.OnDetach.RemoveListener(OnRightArmDetached);
    }

    private void OnLeftArmAttached()
    {
        m_UI.UpdateLeftArmStatusText("Attached");
    }

    private void OnLeftArmDetached()
    {
        m_UI.UpdateLeftArmStatusText("Detached");
    }

    private void OnRightArmAttached()
    {
        m_UI.UpdateRightArmStatusText("Attached");
    }

    private void OnRightArmDetached()
    {
        m_UI.UpdateRightArmStatusText("Detached");
    }

    public void ResetRobot()
    {
        m_RobotCharacter.ResetRobot();
    }
    
    public void DestroyRobot()
    {
        m_RobotCharacter.DestroyRobot();
    }

    public void SetOrbitCameraRotationDirection(Vector2 direction)
    {
        m_OrbitCamera.SetRotationDirection(direction);
    }
}
