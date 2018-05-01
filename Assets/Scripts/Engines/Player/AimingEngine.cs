using Svelto.ECS;
using System.Collections;

public class AimingEngine : MultiEntityViewsEngine<PlayerEV, CrossHairEV>
{
    private PlayerEV m_Player;
    private CrossHairEV m_Crosshair;

    public void Ready()
    { }

    protected override void Add(CrossHairEV entityView)
    {
        m_Crosshair = entityView;
    }

    protected override void Add(PlayerEV entityView)
    {
        m_Player = entityView;
        MoveCrosshair().Run();
    }

    private IEnumerator MoveCrosshair()
    {
        while (m_Crosshair == null) yield return null;

        while (true)
        {
            m_Crosshair.positionComponent.position = m_Player.inputComponent.aimPos;
            yield return null;
        }
    }


    protected override void Remove(CrossHairEV entityView)
    {
        m_Crosshair = null;
    }

    protected override void Remove(PlayerEV entityView)
    {
        m_Player = null;
    }
}