using Svelto.ECS;
using UnityEngine;

public interface IZombieAnimationComponent : IComponent
{
    string trigger { set; }
}

public interface IZombieMovementComponent : IComponent
{
    bool navMeshEnabled { set; }
    Vector3 navMeshDestination { set; }
}

public interface IZombieTriggerComponent : IComponent
{
    DispatchOnSet<bool> triggeredAgainstTarget { get; set; }
    bool isActive { set; }
}

public interface IZombieAttackComponent : IComponent
{
    int damagePerFrame { get; }
}