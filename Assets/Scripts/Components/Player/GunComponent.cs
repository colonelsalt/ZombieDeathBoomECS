using Svelto.ECS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunComponent : IComponent
{
    int damagePerShot { get; }
    DispatchOnSet<Vector3> lastImpactPos { get; }
    GameObject bloodEffectPrefab { get; }
}
