using Svelto.ECS;

public class PlayerEV : EntityView
{
    public IPlayerInputComponent inputComponent;

    public IGunComponent gunComponent;

    public IHealthComponent healthComponent;
}

public class ZombieDestinationEV : EntityView
{
    public IPositionComponent positionComponent;

    public IHealthComponent healthComponent;
}

