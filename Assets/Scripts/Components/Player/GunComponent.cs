using Svelto.ECS;
using UnityEngine;

public interface IGunComponent : IComponent
{
    int damagePerShot { get; }
    DispatchOnSet<Vector3> lastImpactPos { get; }
    GameObject bloodEffectPrefab { get; }
}
