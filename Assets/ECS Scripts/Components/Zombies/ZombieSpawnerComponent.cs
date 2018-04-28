using Svelto.ECS;
using UnityEngine;

public interface IZombieSpawnerComponent : IComponent
{
    DispatchOnSet<int> lastSpawnedID { get; set; }

    Vector3[] spawnPositions { get; }

    GameObject zombieToSpawn { get; }

    float secsBetweenSpawns { get; }
}

