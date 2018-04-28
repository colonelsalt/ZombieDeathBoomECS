using UnityEngine;

public class ZombieAttackImplementor : MonoBehaviour, IImplementor, IZombieAttackComponent
{
    [SerializeField]
    private int m_DamagePerFrame = 1;

    public int damagePerFrame
    {
        get
        {
            return m_DamagePerFrame;
        }
    }
}