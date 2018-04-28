using UnityEngine;

public class ZombieAnimationImplementor : MonoBehaviour, IImplementor, IZombieAnimationComponent
{
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();        
    }

    public string trigger
    {
        set
        {
            m_Animator.SetTrigger(value);
        }
    }
}