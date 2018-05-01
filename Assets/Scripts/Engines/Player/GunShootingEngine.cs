using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Svelto.ECS;
using Svelto.Tasks;
using System;

public class GunShootingEngine : SingleEntityViewEngine<PlayerEV>, IQueryingEntityViewEngine
{
    // --------------------------------------------------------------

    private PlayerEV m_PlayerEntity;

    private IRayCaster m_RayCaster;

    // --------------------------------------------------------------

    public IEntityViewsDB entityViewsDB { set; private get; }

    // --------------------------------------------------------------

    public GunShootingEngine(IRayCaster rayCaster)
    {
        m_RayCaster = rayCaster;
    }

    public void Ready()
    {
        
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
