using UnityEngine;
using UnityEngine.AI;
using Svelto.ECS;

public class ZombieMovementImplementor : MonoBehaviour, IImplementor, IZombieMovementComponent
{
    // --------------------------------------------------------------

    private NavMeshAgent m_Nav;

    // --------------------------------------------------------------

    public bool navMeshEnabled
    {
        set
        {
            m_Nav.enabled = value;
        }
    }

    public Vector3 navMeshDestination
    {
        set
        {
            m_Nav.destination = value;
        }
    }

    // --------------------------------------------------------------

    private void Awake()
    {
        m_Nav = GetComponent<NavMeshAgent>();
    }
}