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

    protected override void Add(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = entityView;
    }

    protected override void Remove(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = null;
    }
}
