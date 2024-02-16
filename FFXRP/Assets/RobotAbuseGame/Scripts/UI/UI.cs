using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Game m_Game = null;
    [SerializeField] private HoldableButton m_UpButton = null;
    [SerializeField] private HoldableButton m_DownButton = null;
    [SerializeField] private HoldableButton m_LeftButton = null;
    [SerializeField] private HoldableButton m_RightButton = null;
    [SerializeField] private TMP_Text m_LeftArmAttachedDetachedText = null;
    [SerializeField] private TMP_Text m_RightArmAttachedDetachedText = null;

    //There seems to be a bug in unity's serialization of UnityEvent exposing to the editor, due to time constraints we add and remove event listeners in the component

    private void OnEnable()
    {
        m_UpButton.OnHoldDownButton.AddListener(OnHoldUpButton);
        m_UpButton.OnLetGoButton.AddListener(OnLetGoUpButton);
        m_DownButton.OnHoldDownButton.AddListener(OnHoldDownButton);
        m_DownButton.OnLetGoButton.AddListener(OnLetGoDownButton);
        m_LeftButton.OnHoldDownButton.AddListener(OnHoldLeftButton);
        m_LeftButton.OnLetGoButton.AddListener(OnLetGoLeftButton);
        m_RightButton.OnHoldDownButton.AddListener(OnHoldRightButton);
        m_RightButton.OnLetGoButton.AddListener(OnLetGoRightButton);
    }

    private void OnDisable()
    {
        m_UpButton.OnHoldDownButton.RemoveListener(OnHoldUpButton);
        m_UpButton.OnLetGoButton.RemoveListener(OnLetGoUpButton);
        m_DownButton.OnHoldDownButton.RemoveListener(OnHoldDownButton);
        m_DownButton.OnLetGoButton.RemoveListener(OnLetGoDownButton);
        m_LeftButton.OnHoldDownButton.RemoveListener(OnHoldLeftButton);
        m_LeftButton.OnLetGoButton.RemoveListener(OnLetGoLeftButton);
        m_RightButton.OnHoldDownButton.RemoveListener(OnHoldRightButton);
        m_RightButton.OnLetGoButton.RemoveListener(OnLetGoRightButton);
    }

    public void UpdateLeftArmStatusText(string text)
    {
        m_LeftArmAttachedDetachedText.text = text;
    }

    public void UpdateRightArmStatusText(string text)
    {
        m_RightArmAttachedDetachedText.text = text;
    }

    public void OnPressResetButton()
    {
        m_Game.ResetRobot();
    }

    public void OnPressDestroyButton()
    {
        m_Game.DestroyRobot();
    }

    public void OnPressQuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    private void OnHoldUpButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.left);
    }

    private void OnLetGoUpButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.zero);
    }

    private void OnHoldDownButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.right);
    }

    private void OnLetGoDownButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.zero);
    }

    private void OnHoldLeftButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.up);
    }

    private void OnLetGoLeftButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.zero);
    }

    private void OnHoldRightButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.down);
    }

    private void OnLetGoRightButton()
    {
        m_Game.SetOrbitCameraRotationDirection(Vector2.zero);
    }
}
