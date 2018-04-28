using Svelto.ECS;
using UnityEngine;

public class GunImplementor : MonoBehaviour, IImplementor, IGunComponent
{
    [SerializeField]
    private int m_DamagePerShot = 1;

    [SerializeField]
    private GameObject m_BloodPrefab;

    public int damagePerShot { get { return m_DamagePerShot; } }

    public DispatchOnSet<Vector3> lastImpactPos { get; private set; }

    public GameObject bloodEffectPrefab { get { return m_BloodPrefab; } }

    private void Awake()
    {
        lastImpactPos = new DispatchOnSet<Vector3>(gameObject.GetInstanceID());
    }

}