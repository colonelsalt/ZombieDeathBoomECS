using UnityEngine;

public class SoundImplementor : MonoBehaviour, IImplementor, ISoundComponent
{
    [SerializeField]
    private AudioClip[] m_DeathSounds;

    [SerializeField]
    private AudioClip[] m_SpawnSounds;

    [SerializeField]
    private AudioClip[] m_AttackSounds;

    [SerializeField]
    private AudioClip[] m_GunSounds;

    private AudioSource m_Audio;

    public SoundType clipToPlay
    {
        set
        {
            switch (value)
            {
                case SoundType.ZOMBIE_DEATH:
                    m_Audio.PlayOneShot(m_DeathSounds[Random.Range(0, m_DeathSounds.Length)]);
                    break;
                case SoundType.ZOMBIE_SPAWN:
                    m_Audio.PlayOneShot(m_SpawnSounds[Random.Range(0, m_SpawnSounds.Length)]);
                    break;
                case SoundType.ZOMBIE_ATTACK:
                    m_Audio.clip = m_AttackSounds[Random.Range(0, m_AttackSounds.Length)];
                    m_Audio.Play();
                    break;
                case SoundType.GUNSHOT:
                    m_Audio.PlayOneShot(m_GunSounds[Random.Range(0, m_GunSounds.Length)]);
                    break;
            }
        }
    }

    public bool isPlaying
    {
        set
        {
            m_Audio.Stop();
        }
    }

    private void Awake()
    {
        m_Audio = GetComponent<AudioSource>();
    }
}