using UnityEngine;
using Svelto.ECS;
using System.Collections;

public class PlayerInputEngine : SingleEntityViewEngine<PlayerEV>
{
    // --------------------------------------------------------------

    private ICamera m_Camera;

    private PlayerEV m_PlayerEntity;

    // --------------------------------------------------------------

    public PlayerInputEngine(ICamera camera)
    {
        m_Camera = camera;
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