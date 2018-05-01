using Svelto.ECS;
using UnityEngine;

public class ZombieSpawnerImplementor : MonoBehaviour, IImplementor, IZombieSpawnerComponent
{
    // --------------------------------------------------------------

    [SerializeField]
    private GameObject m_ZombiePrefab;

    [SerializeField]
    private float m_SecsBetweenSpawns = 3f;

    // --------------------------------------------------------------

    public DispatchOnSet<int> lastSpawnedID { get; set; }

    public Vector3[] spawnPositions { get; private set; }

    public GameObject zombieToSpawn
    {
        get
        {
            return m_ZombiePrefab;
        }
    }

    public float secsBetweenSpawns
    {
        get
        {
            return m_SecsBetweenSpawns;
        }
    }

    // --------------------------------------------------------------

    private void Awake()
    {
        lastSpawnedID = new DispatchOnSet<int>(gameObject.GetInstanceID());

        spawnPositions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; ++i)
        {
            spawnPositions[i] = transform.GetChild(i).position;
        }
    }

}
