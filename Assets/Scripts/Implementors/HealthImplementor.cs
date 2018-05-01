using System.Collections;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

public class HealthImplementor : MonoBehaviour, IImplementor, IHealthComponent
{
    [SerializeField]
    private float m_MaxHealth;

    public DispatchOnSet<float> currentHealth { get; set; }

    public DispatchOnSet<bool> isAlive { get; set; }

    public float maxHealth
    {
        get
        {
            return m_MaxHealth;
        }
    }

    private void Awake()
    {
        currentHealth = new DispatchOnSet<float>(gameObject.GetInstanceID())
        {
            value = m_MaxHealth
        };

        isAlive = new DispatchOnSet<bool>(gameObject.GetInstanceID())
        {
            value = true
        };
    }

}
