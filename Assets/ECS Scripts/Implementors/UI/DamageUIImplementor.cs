using UnityEngine;
using UnityEngine.UI;
using Svelto.ECS;

public class DamageUIImplementor : MonoBehaviour, IImplementor, IDamageUIComponent
{
    private Image m_OverlayPanel;

    private Color m_OverlayColour;

    public float overlayIntensity
    {
        set
        {
            m_OverlayColour.a = value;
            m_OverlayPanel.color = m_OverlayColour;
        }
    }

    private void Awake()
    {
        m_OverlayPanel = GetComponent<Image>();
        m_OverlayColour = m_OverlayPanel.color;
    }
}
