public interface ISoundComponent : IComponent
{
    SoundType clipToPlay { set; }

    bool isPlaying { set; }
}

public enum SoundType
{
    GUNSHOT,
    ZOMBIE_SPAWN,
    ZOMBIE_DEATH,
    ZOMBIE_ATTACK
}