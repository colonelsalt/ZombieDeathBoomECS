using Svelto.ECS;

public class ZombieEV : EntityView
{
    public IZombieMovementComponent movementComponent;

    public IZombieAnimationComponent animationComponent;

    public IZombieAttackComponent attackComponent;

    public IZombieTriggerComponent triggerComponent;

    public IHealthComponent healthComponent;
}

public class GunTargetEV : EntityView
{
    public IHealthComponent healthComponent;
}