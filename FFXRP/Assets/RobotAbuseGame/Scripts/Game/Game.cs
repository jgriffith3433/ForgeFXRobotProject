using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private RobotCharacter m_RobotCharacter = null;

    public void ResetRobot()
    {
        m_RobotCharacter.ResetRobot();
    }
    
    public void DestroyRobot()
    {
        m_RobotCharacter.DestroyRobot();
    }
}
