using Svelto.ECS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEV : EntityView
{
    public IPlayerInputComponent inputComponent;

    public IGunComponent gunComponent;

    public ISoundComponent soundComponent;

    public ICameraComponent cameraComponent;

    public IHealthComponent healthComponent;
}

public class ZombieDestinationEV : EntityView
{
    public IPositionComponent positionComponent;

    public IHealthComponent healthComponent;
}

