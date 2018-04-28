using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Svelto.ECS;
using Svelto.Tasks;
using System;

public class GunShootingEngine : SingleEntityViewEngine<PlayerEV>, IQueryingEntityViewEngine
{
    public IEntityViewsDB entityViewsDB { set; private get; }

    private PlayerEV m_PlayerEntity;

    private IRayCaster m_RayCaster;
   
    public void Ready()
    {
        Tick().Run();
    }

    public GunShootingEngine(IRayCaster rayCaster)
    {
        m_RayCaster = rayCaster;
    }

    private IEnumerator Tick()
    {
        while (m_PlayerEntity == null) yield return null;

        while (m_PlayerEntity.healthComponent.currentHealth.value > 0f)
        {
            if (m_PlayerEntity.inputComponent.isFiring)
            {
                Shoot();
            }

            yield return null;
        }
    }

    private void Shoot()
    {
        Vector3 impactPoint;
        int entityHitID = m_RayCaster.GetRayHitTarget(m_PlayerEntity.inputComponent.aimRay, out impactPoint);

        m_PlayerEntity.soundComponent.clipToPlay = SoundType.GUNSHOT;

        if (entityHitID == -1)
        {
            return;
        }

        GunTargetEV gunTarget;
        // Check if the target we hit is a valid gun target (i.e. in our case a zombie)
        if (entityViewsDB.TryQueryEntityView(entityHitID, out gunTarget))
        {
            gunTarget.healthComponent.currentHealth.value -= m_PlayerEntity.gunComponent.damagePerShot;
            m_PlayerEntity.gunComponent.lastImpactPos.value = impactPoint;
        }
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
