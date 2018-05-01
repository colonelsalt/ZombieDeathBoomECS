using UnityEngine;

public interface ICamera : IComponent
{
    Ray ScreenPointToRay(Vector3 screenPos);
}