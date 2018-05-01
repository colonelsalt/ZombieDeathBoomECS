using Svelto.ECS;
using Svelto.Context;
using UnityEngine;

public class GunEffectsEngine : SingleEntityViewEngine<PlayerEV>
{
    // --------------------------------------------------------------

    private PlayerEV m_PlayerEntity;

    private GameObjectFactory m_GameObjectFactory;

    // --------------------------------------------------------------

    public GunEffectsEngine(GameObjectFactory gameObjectFactory)
    {
        m_GameObjectFactory = gameObjectFactory;
    }

    protected override void Add(PlayerEV entityView)
    {
        m_PlayerEntity = entityView;
    }

    protected override void Remove(PlayerEV entityView)
    {
        m_PlayerEntity = null;
    }
}
