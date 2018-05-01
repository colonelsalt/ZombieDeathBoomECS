using Svelto.Context;
using Svelto.ECS;
using Svelto.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ZombieSpawnerEngine : SingleEntityViewEngine<ZombieSpawnerEV>
{
    // --------------------------------------------------------------

    private GameObjectFactory m_GameObjectFactory;

    private IEntityFactory m_EntityFactory;

    private ZombieSpawnerEV m_ZombieSpawner;

    private WaitForSeconds m_WaitTime;

    // --------------------------------------------------------------

    public ZombieSpawnerEngine(GameObjectFactory gameObjectFactory, IEntityFactory entityFactory)
    {
        m_GameObjectFactory = gameObjectFactory;
        m_EntityFactory = entityFactory;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return m_WaitTime;
            Vector3 randomPos = m_ZombieSpawner.spawnerComponent.spawnPositions[Random.Range(0, m_ZombieSpawner.spawnerComponent.spawnPositions.Length)];
            GameObject zombie = m_GameObjectFactory.Build(m_ZombieSpawner.spawnerComponent.zombieToSpawn);
            zombie.transform.position = randomPos;

            List<IImplementor> implementors = new List<IImplementor>();
            zombie.GetComponentsInChildren(implementors);

            m_EntityFactory.BuildEntity<ZombieEntity>(zombie.GetInstanceID(), implementors.ToArray());
            
            //Debug.Log("Spawned zombie with ID " + zombie.GetInstanceID());

            yield return null;
            m_ZombieSpawner.spawnerComponent.lastSpawnedID.value = zombie.GetInstanceID();
        }
    }

    protected override void Add(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = entityView;
        m_WaitTime = new WaitForSeconds(m_ZombieSpawner.spawnerComponent.secsBetweenSpawns);
        Spawn().Run();
    }

    protected override void Remove(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = null;
    }
}
