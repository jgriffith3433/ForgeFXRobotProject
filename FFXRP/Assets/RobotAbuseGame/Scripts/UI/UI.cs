using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private Game m_Game = null;

    public void OnPressResetButton()
    {
        m_Game.ResetRobot();
    }

    public void OnPressDestroyButton()
    {
        m_Game.DestroyRobot();
    }
}
