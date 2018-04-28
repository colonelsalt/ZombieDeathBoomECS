using Svelto.ECS;
using System;
using System.Collections;

public class DeathEngine : SingleEntityViewEngine<ZombieSpawnerEV>, IQueryingEntityViewEngine
{
    private ZombieSpawnerEV m_ZombieSpawner;

    private IEntityFunctions m_EntityFunctions;

    public IEntityViewsDB entityViewsDB { set; private get; }

    public DeathEngine(IEntityFunctions entityFunctions)
    {
        m_EntityFunctions = entityFunctions;
    }

    public void Ready()
    {
    }

    private void OnZombieSpawned(int spawnerID, int zombieID)
    {
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(zombieID);

        zombie.healthComponent.currentHealth.NotifyOnValueSet(OnZombieDamaged);
        zombie.deathComponent.isAlive.NotifyOnValueSet(OnZombieDeath);
    }

    private void OnZombieDamaged(int ID, float currentHealth)
    {
        if (currentHealth <= 0)
        {
            ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(ID);
            zombie.soundComponent.clipToPlay = SoundType.ZOMBIE_DEATH;
            zombie.deathComponent.isAlive.value = false;
            zombie.triggerComponent.isActive = false;
        }
    }

    private void OnZombieDeath(int ID, bool isAlive)
    {
        m_EntityFunctions.RemoveEntity(ID);
    }

    protected override void Add(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = entityView;
        m_ZombieSpawner.spawnerComponent.lastSpawnedID.NotifyOnValueSet(OnZombieSpawned);
    }

    protected override void Remove(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = null;
    }
}