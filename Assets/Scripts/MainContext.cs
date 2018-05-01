using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Svelto.ECS;
using Svelto.Context;
using System;
using Svelto.ECS.Schedulers.Unity;
using Svelto.Tasks;

public class Main : ICompositionRoot
{
    // --------------------------------------------------------------

    private EnginesRoot m_EnginesRoot;

    private IEntityFactory m_EntityFactory;

    // --------------------------------------------------------------


    public Main()
    {
        SetupEngines();
    }


    void SetupEngines()
    {
        // "The core of Svelto.ECS" ???
        m_EnginesRoot = new EnginesRoot(new UnitySumbmissionEntityViewScheduler());

        // Factory for creating all entities (?)
        m_EntityFactory = m_EnginesRoot.GenerateEntityFactory();

        // ???
        IEntityFunctions entityFunctions = m_EnginesRoot.GenerateEntityFunctions();

        // Factory used to create Unity GameObjects (wrapper around GameObject.Instantiate)
        GameObjectFactory gameObjectFactory = new GameObjectFactory();

        IRayCaster rayCaster = new RayCaster();
        ITime time = new FrameTimer();

        PlayerInputEngine playerInputEngine = new PlayerInputEngine();
        AimingEngine aimingEngine = new AimingEngine();
        GunShootingEngine gunShootingEngine = new GunShootingEngine(rayCaster);
        GunEffectsEngine gunEffectsEngine = new GunEffectsEngine(gameObjectFactory);
        ZombieSpawnerEngine zombieSpawnerEngine = new ZombieSpawnerEngine(gameObjectFactory, m_EntityFactory);
        ZombieMovementEngine zombieMovementEngine = new ZombieMovementEngine(time);
        ZombieAnimationEngine zombieAnimationEngine = new ZombieAnimationEngine();
        HUDEngine hudEngine = new HUDEngine();
        DeathEngine deathEngine = new DeathEngine(entityFunctions);

        m_EnginesRoot.AddEngine(playerInputEngine);
        m_EnginesRoot.AddEngine(aimingEngine);
        m_EnginesRoot.AddEngine(gunShootingEngine);
        m_EnginesRoot.AddEngine(gunEffectsEngine);
        m_EnginesRoot.AddEngine(zombieSpawnerEngine);
        m_EnginesRoot.AddEngine(zombieMovementEngine);
        m_EnginesRoot.AddEngine(zombieAnimationEngine);
        m_EnginesRoot.AddEngine(hudEngine);
        m_EnginesRoot.AddEngine(deathEngine);

    }

    public void OnContextCreated(UnityContext contextHolder)
    {
        IEntityDescriptorHolder[] entities = contextHolder.GetComponentsInChildren<IEntityDescriptorHolder>();

        foreach (IEntityDescriptorHolder entity in entities)
        {
            IEntityDescriptorInfo entityInfo = entity.RetrieveDescriptor();
            m_EntityFactory.BuildEntity(((MonoBehaviour)entity).gameObject.GetInstanceID(), entityInfo,
                (entity as MonoBehaviour).GetComponentsInChildren<IImplementor>());
        }

        GameObject player = Camera.main.gameObject;
        List<IImplementor> implementors = new List<IImplementor>();
        player.GetComponents(implementors);
        implementors.Add(new PlayerInputImplementor());

        m_EntityFactory.BuildEntity<PlayerEntity>(player.GetInstanceID(), implementors.ToArray());
    }

    public void OnContextDestroyed()
    {
        m_EnginesRoot.Dispose();
        TaskRunner.Instance.StopAndCleanupAllDefaultSchedulerTasks();
    }

    public void OnContextInitialized() { }
}

// This will be called by Awake and instantiate Main
public class MainContext : UnityContext<Main> { }