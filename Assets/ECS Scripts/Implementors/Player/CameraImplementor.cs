using UnityEngine;

public class CameraImplementor : MonoBehaviour, IImplementor, ICameraComponent
{
    private Camera m_Camera;

    public Ray ScreenPointToRay(Vector3 screenPos)
    {
        return m_Camera.ScreenPointToRay(screenPos);
    }

    private void Awake()
    {
        m_Camera = GetComponent<Camera>();
    }
}