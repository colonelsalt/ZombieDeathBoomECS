using Svelto.ECS;


class ZombieAnimationEngine : SingleEntityViewEngine<ZombieSpawnerEV>, IQueryingEntityViewEngine
{
    // --------------------------------------------------------------

    private ZombieSpawnerEV m_ZombieSpawner;

    // --------------------------------------------------------------

    public IEntityViewsDB entityViewsDB { set; private get; }

    // --------------------------------------------------------------

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

