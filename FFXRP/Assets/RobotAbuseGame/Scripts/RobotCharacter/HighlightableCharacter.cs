using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightableCharacter : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_RootRenderer = null;
    [SerializeField] private Color m_MouseOverColor = Color.red;

    private bool m_Hovering;
    private MeshRenderer[] m_ChildMeshRenderers = null;
    private List<Color> m_ChildMeshRenderersOriginalColors = null;

    private void Awake()
    {
        m_ChildMeshRenderers = m_RootRenderer.GetComponentsInChildren<MeshRenderer>();
        m_ChildMeshRenderersOriginalColors = new List<Color>();
        foreach (var childMeshRenderer in m_ChildMeshRenderers)
        {
            m_ChildMeshRenderersOriginalColors.Add(childMeshRenderer.material.color);
        }
    }

    private void OnMouseEnter()
    {
        m_Hovering = true;
        for (var i = 0; i < m_ChildMeshRenderers.Length; i++)
        {
            m_ChildMeshRenderers[i].material.color = m_MouseOverColor;
        }
    }

    private void OnMouseExit()
    {
        m_Hovering = false;
        for (var i = 0; i < m_ChildMeshRenderers.Length; i++)
        {
            m_ChildMeshRenderers[i].material.color = m_ChildMeshRenderersOriginalColors[i];
        }
    }


}
