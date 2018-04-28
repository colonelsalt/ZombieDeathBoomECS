using UnityEngine;
using Svelto.ECS;
using System.Collections;

public class PlayerInputEngine : SingleEntityViewEngine<PlayerEV>
{
    private PlayerEV m_PlayerEntity;

    protected override void Add(PlayerEV entityView)
    {
        m_PlayerEntity = entityView;
        ReadInput().Run();
    }

    private IEnumerator ReadInput()
    {
        while (true)
        {
            m_PlayerEntity.inputComponent.aimRay = m_PlayerEntity.cameraComponent.ScreenPointToRay(Input.mousePosition);
            m_PlayerEntity.inputComponent.aimPos = Input.mousePosition;
            m_PlayerEntity.inputComponent.isFiring = Input.GetButtonDown("Fire1");

            yield return null;
        }
    }

    protected override void Remove(PlayerEV entityView)
    {
        m_PlayerEntity = null;
    }
}