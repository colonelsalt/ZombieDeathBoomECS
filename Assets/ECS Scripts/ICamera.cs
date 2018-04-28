using UnityEngine;


public interface ICameraComponent : IComponent
{
    Ray ScreenPointToRay(Vector3 screenPos);
}