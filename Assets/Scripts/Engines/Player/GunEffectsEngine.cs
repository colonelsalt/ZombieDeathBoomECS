using Svelto.ECS;
using Svelto.Context;
using UnityEngine;

public class GunEffectsEngine : SingleEntityViewEngine<PlayerEV>
{
    private PlayerEV m_PlayerEntity;

    private GameObjectFactory m_GameObjectFactory;

    public GunEffectsEngine(GameObjectFactory gameObjectFactory)
    {
        m_GameObjectFactory = gameObjectFactory;
    }

    protected override void Add(PlayerEV entityView)
    {
        m_PlayerEntity = entityView;
        m_PlayerEntity.gunComponent.lastImpactPos.NotifyOnValueSet(OnGunImpact);
    }

    protected override void Remove(PlayerEV entityView)
    {
        m_PlayerEntity = null;
    }

    private void OnGunImpact(int ID, Vector3 impactPos)
    {
        // Instantiate blood effect prefab at impactPos
        GameObject blood = m_GameObjectFactory.Build(m_PlayerEntity.gunComponent.bloodEffectPrefab);
        blood.transform.position = impactPos;
    }
}
