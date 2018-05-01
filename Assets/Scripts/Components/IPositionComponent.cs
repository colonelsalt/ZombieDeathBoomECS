using UnityEngine;

public interface IPositionComponent : IComponent
{
    Vector3 position { get; set; }
}