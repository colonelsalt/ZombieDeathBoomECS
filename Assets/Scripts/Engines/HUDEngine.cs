using Svelto.ECS;
using System.Collections;
using Svelto.Tasks;
using UnityEngine;
using System;

public class HUDEngine : MultiEntityViewsEngine<HUDEV, PlayerEV>, IQueryingEntityViewEngine
{
    private HUDEV m_HUD;

    private PlayerEV m_Player;

    public IEntityViewsDB entityViewsDB { set; private get; }

    public void Ready()
    { }

    private void OnNewZombieSpawned(int spawnerID, int zombieID)
    {
        // Update score every time a zombie dies
        ZombieEV zombie = entityViewsDB.QueryEntityView<ZombieEV>(zombieID);
        zombie.deathComponent.isAlive.NotifyOnValueSet(OnScoreUpdate);
    }

    protected override void Add(HUDEV entityView)
    {
        m_HUD = entityView;
        ZombieSpawnerEV zombieSpawner = entityViewsDB.QueryEntityViews<ZombieSpawnerEV>()[0];
        zombieSpawner.spawnerComponent.lastSpawnedID.NotifyOnValueSet(OnNewZombieSpawned);
    }

    protected override void Remove(HUDEV entityView)
    {
        m_HUD = null;
    }

    private void OnScoreUpdate(int ID, bool isAlive)
    {
        m_HUD.scoreComponent.currentScore += m_HUD.scoreComponent.pointsPerKill;
    }

    private void OnScreenRedden(int ID, float currentHealth)
    {
        Debug.Log("Player now has health " + currentHealth);
        m_HUD.screenDamageComponent.overlayIntensity = 1 - (currentHealth / m_Player.healthComponent.maxHealth);
        if (currentHealth <= 0f)
        {
            m_HUD.gameOverComponent.isGameOver = true;
        }
    }

    protected override void Add(PlayerEV entityView)
    {
        m_Player = entityView;
        m_Player.healthComponent.currentHealth.NotifyOnValueSet(OnScreenRedden);
    }

    protected override void Remove(PlayerEV entityView)
    {
        m_Player = null;
    }
}
