using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Android.AndroidBuild;

public class UIController : MonoBehaviour
{
    PanelRenderer m_PanelRenderer;
    int m_Version = 0;
    VisualElement uiRoot;
    Button tower1;

    void Start()
    {
        tower1 = uiRoot.Q<Button>("Tower1Button");

        tower1.clicked += OnTower1Clicked;
    }

    void OnTower1Clicked()
    {

    }


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
        uiRoot = rootElement.Q<VisualElement>("BuildPanel");


    }


}
