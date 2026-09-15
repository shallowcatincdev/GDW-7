using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class BuildPanel : MonoBehaviour
{

    PanelRenderer m_PanelRenderer;
    int m_Version = 0;
    VisualElement buildPanel;

    void OnEnable()
    {
        m_PanelRenderer = GetComponent<PanelRenderer>();
        m_PanelRenderer.RegisterUIReloadCallback(OnUIReload);
    }

    void OnDisable()
    {
        m_PanelRenderer.UnregisterUIReloadCallback(OnUIReload);
    }

    void OnUIReload(PanelRenderer panelRenderer, VisualElement rootElement, int version)
    {
        if (version == m_Version)
            return;

        m_Version = version;
        buildPanel = rootElement.Q<VisualElement>("BuildPanel");

        
    }

    public void ToggleMovement()
    {
        buildPanel.ToggleInClassList("build-panel-shifted");
    }
}
   


