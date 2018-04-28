using UnityEngine;
using Svelto.ECS;

public class ZombieEV : EntityView
{
    public IZombieMovementComponent movementComponent;

    public IZombieAnimationComponent animationComponent;

    public IZombieAttackComponent attackComponent;

    public IZombieTriggerComponent triggerComponent;

    public IHealthComponent healthComponent;

    public IDeathComponent deathComponent;

    public ISoundComponent soundComponent;
}

public class GunTargetEV : EntityView
{
    public IHealthComponent healthComponent;
}