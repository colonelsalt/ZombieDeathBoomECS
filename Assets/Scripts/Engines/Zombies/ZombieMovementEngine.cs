using UnityEngine;
using Svelto.ECS;
using Svelto.DataStructures;
using System.Collections;
using Svelto.Tasks;

class ZombieMovementEngine : SingleEntityViewEngine<ZombieSpawnerEV>, IQueryingEntityViewEngine
{
    // --------------------------------------------------------------

    private ITime m_Time;

    private ZombieSpawnerEV m_ZombieSpawner;

    // --------------------------------------------------------------

    public IEntityViewsDB entityViewsDB { set; private get; }

    // --------------------------------------------------------------

    public ZombieMovementEngine(ITime time)
    {
        m_Time = time;
    }

    public void Ready()
    { }

    protected override void Add(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = entityView;
    }

    protected override void Remove(ZombieSpawnerEV entityView)
    {
        m_ZombieSpawner = null;
    }
}