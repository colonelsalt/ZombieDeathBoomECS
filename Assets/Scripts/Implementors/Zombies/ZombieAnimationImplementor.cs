using UnityEngine;

public class ZombieAnimationImplementor : MonoBehaviour, IImplementor, IZombieAnimationComponent
{
    // --------------------------------------------------------------

    private Animator m_Animator;

    // --------------------------------------------------------------

    public string trigger
    {
        set
        {
            m_Animator.SetTrigger(value);
        }
    }

    // --------------------------------------------------------------

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();        
    }
}