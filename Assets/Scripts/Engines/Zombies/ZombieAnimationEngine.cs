using Svelto.ECS;


class ZombieAnimationEngine : SingleEntityViewEngine<ZombieSpawnerEV>, IQueryingEntityViewEngine
{
    ZombieSpawnerEV m_ZombieSpawner;

    public IEntityViewsDB entityViewsDB { set; private get; }

    public void Ready()
    { }

    private void OnSetupAnimationTriggers(int spawnerID, int zombieID)
    {
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(zombieID);

        zombie.triggerComponent.triggeredAgainstTarget.NotifyOnValueSet(OnBeginAttack);
        zombie.deathComponent.isAlive.NotifyOnValueSet(OnZombieDeath);
    }

    private void OnBeginAttack(int ID, bool didTrigger)
    {
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(ID);
        zombie.animationComponent.trigger = "attackTrigger";
    }

    private void OnZombieDeath(int ID, bool didDie)
    {
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(ID);
        zombie.animationComponent.trigger = "deathTrigger";
    }

    protected override void Add(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = entityView;
        m_ZombieSpawner.spawnerComponent.lastSpawnedID.NotifyOnValueSet(OnSetupAnimationTriggers);
    }

    protected override void Remove(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = null;
    }
}

