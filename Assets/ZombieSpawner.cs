using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    [SerializeField]
    private float m_TimeBetweenSpawns = 3;

    [SerializeField]
    private GameObject m_ObjectToSpawn;

    private float m_TimeSinceLastSpawn = 0f;

    private Transform[] m_SpawnPositions;

    private void Awake()
    {
        SetupSpawners();
        Debug.Log("Found " + m_SpawnPositions.Length + " spawn positions.");
    }

    private void OnDrawGizmos()
    {
        SetupSpawners();
        foreach (Transform spawnPoint in m_SpawnPositions)
        {
            Gizmos.DrawWireSphere(spawnPoint.position, 1f);
        }
    }

    private void SetupSpawners()
    {
        m_SpawnPositions = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            m_SpawnPositions[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        m_TimeSinceLastSpawn += Time.deltaTime;
        
        if (m_TimeSinceLastSpawn >= m_TimeBetweenSpawns)
        {
            Spawn();
        }

    }

    private void Spawn()
    {
        Transform spawnPos = m_SpawnPositions[Random.Range(0, m_SpawnPositions.Length)];
        Instantiate(m_ObjectToSpawn, spawnPos);
        m_TimeSinceLastSpawn = 0f;
    }
}
