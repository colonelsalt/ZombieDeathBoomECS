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

    private void SetupEngines()
    {
        m_EnginesRoot = new EnginesRoot(new UnitySumbmissionEntityViewScheduler());

        // Factory for building new entities in-game
        m_EntityFactory = m_EnginesRoot.GenerateEntityFactory();
        // Factory used to create Unity GameObjects in-game (wrapper around GameObject.Instantiate)
        GameObjectFactory gameObjectFactory = new GameObjectFactory();

        // Utility functions (needed for e.g. removing entities in-game)
        IEntityFunctions entityFunctions = m_EnginesRoot.GenerateEntityFunctions();

        // Create utility objects
        IRayCaster rayCaster = new RayCaster();
        ITime time = new FrameTimer();
        ICamera camera = Camera.main.GetComponent<UnityCamera>();

        // Instantiate all engines
        PlayerInputEngine playerInputEngine = new PlayerInputEngine(camera);
        GunShootingEngine gunShootingEngine = new GunShootingEngine(rayCaster);
        GunEffectsEngine gunEffectsEngine = new GunEffectsEngine(gameObjectFactory);
        ZombieSpawnerEngine zombieSpawnerEngine = new ZombieSpawnerEngine(gameObjectFactory, m_EntityFactory);
        ZombieMovementEngine zombieMovementEngine = new ZombieMovementEngine(time);
        ZombieAnimationEngine zombieAnimationEngine = new ZombieAnimationEngine();

        // Add all engines to Engine Root
        m_EnginesRoot.AddEngine(playerInputEngine);
        m_EnginesRoot.AddEngine(gunShootingEngine);
        m_EnginesRoot.AddEngine(gunEffectsEngine);
        m_EnginesRoot.AddEngine(zombieSpawnerEngine);
        m_EnginesRoot.AddEngine(zombieMovementEngine);
        m_EnginesRoot.AddEngine(zombieAnimationEngine);
    }

    public void OnContextCreated(UnityContext contextHolder)
    {
        // Retrieve all GameObjects in scene with EntityDescriptorHolders (i.e. GameObjects that are entities)
        IEntityDescriptorHolder[] entities = contextHolder.GetComponentsInChildren<IEntityDescriptorHolder>();

        // Retrieve these GameObjects' Implementors and build them as entities
        foreach (IEntityDescriptorHolder entity in entities)
        {
            IEntityDescriptorInfo entityInfo = entity.RetrieveDescriptor();
            m_EntityFactory.BuildEntity(((MonoBehaviour)entity).gameObject.GetInstanceID(), entityInfo,
                (entity as MonoBehaviour).GetComponentsInChildren<IImplementor>());
        }

        // Retrieve reference to Player GameObject and its Implementors, then build it as an entity
        GameObject player = Camera.main.gameObject;
        List<IImplementor> implementors = new List<IImplementor>();
        player.GetComponents(implementors);
        implementors.Add(new PlayerInputImplementor());

        m_EntityFactory.BuildEntity<PlayerEntity>(player.GetInstanceID(), implementors.ToArray());
    }

    // Final cleanup on scene closed
    public void OnContextDestroyed()
    {
        m_EnginesRoot.Dispose();
        TaskRunner.Instance.StopAndCleanupAllDefaultSchedulerTasks();
    }

    public void OnContextInitialized() { }
}

// This will be called by Awake and instantiate Main
public class MainContext : UnityContext<Main> { }