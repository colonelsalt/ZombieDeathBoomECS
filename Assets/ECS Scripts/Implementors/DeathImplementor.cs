using Svelto.ECS;
using UnityEngine;

public class DeathImplementor : MonoBehaviour, IImplementor, IDeathComponent
{
    [SerializeField]
    private float m_SecsBeforeDestroyed = 3f;

    public DispatchOnSet<bool> isAlive { get; set; }

    private void Awake()
    {
        isAlive = new DispatchOnSet<bool>(gameObject.GetInstanceID())
        {
            value = true
        };
        isAlive.NotifyOnValueSet(OnDeath);
    }

    private void OnDeath(int ID, bool isAlive)
    {
        Destroy(gameObject, m_SecsBeforeDestroyed);
    }

}