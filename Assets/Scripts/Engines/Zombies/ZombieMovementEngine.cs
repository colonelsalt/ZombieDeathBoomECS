using UnityEngine;
using Svelto.ECS;
using Svelto.DataStructures;
using System.Collections;
using Svelto.Tasks;

class ZombieMovementEngine : SingleEntityViewEngine<ZombieSpawnerEV>, IQueryingEntityViewEngine
{
    private ITime m_Time;

    ZombieSpawnerEV m_ZombieSpawner;

    public IEntityViewsDB entityViewsDB { set; private get; }

    public ZombieMovementEngine(ITime time)
    {
        m_Time = time;
    }

    public void Ready()
    { }

    private void SetZombieDestination(int spawnerID, int zombieID)
    {
        ZombieDestinationEV zombieDestination = entityViewsDB.QueryEntityViews<ZombieDestinationEV>()[0];

        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(zombieID);
        zombie.movementComponent.navMeshEnabled = true;
        zombie.movementComponent.navMeshDestination = zombieDestination.positionComponent.position;
        zombie.triggerComponent.triggeredAgainstTarget.NotifyOnValueSet(OnStopMovemement);
        zombie.deathComponent.isAlive.NotifyOnValueSet(OnZombieDeath);
    }

    private void OnStopMovemement(int zombieID, bool triggered)
    {
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(zombieID);
        zombie.movementComponent.navMeshEnabled = false;
        DealDamage(zombieID).Run();
    }

    private IEnumerator DealDamage(int zombieID)
    {
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(zombieID);
        zombie.soundComponent.clipToPlay = SoundType.ZOMBIE_ATTACK;
        while (zombie.deathComponent.isAlive.value)
        {
            ZombieDestinationEV zombieDestination = entityViewsDB.QueryEntityViews<ZombieDestinationEV>()[0];
            zombieDestination.healthComponent.currentHealth.value -= m_Time.deltaTime * zombie.attackComponent.damagePerFrame;
            yield return null;
        }
        zombie.soundComponent.isPlaying = false;
    }

    private void OnZombieDeath(int zombieID, bool isAlive)
    {
        //DealDamage(zombieID).Complete();
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(zombieID);
        zombie.movementComponent.navMeshEnabled = false;
    }

    protected override void Add(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = entityView;
        m_ZombieSpawner.spawnerComponent.lastSpawnedID.NotifyOnValueSet(SetZombieDestination);
    }

    protected override void Remove(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = null;
    }
}