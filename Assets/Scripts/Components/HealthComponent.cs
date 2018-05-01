using Svelto.ECS;

public interface IHealthComponent : IComponent
{
    float maxHealth { get; }
    DispatchOnSet<float> currentHealth { get; set; }
}

public interface IDeathComponent : IComponent
{
    DispatchOnSet<bool> isAlive { get; set; }
}

//public struct DamageInfo
//{
//    public int damagePerShot { get; private set; }
//    public int entityDamagedID { get; private set; }
//    public DamagableEntityType entityType { get; private set; }

//    public DamageInfo(int damage, int entityID, DamagableEntityType type)
//    {
//        damagePerShot = damage;
//        entityDamagedID = entityID;
//        entityType = type;
//    }
//}

//public enum DamagableEntityType
//{
//    Zombie,
//    Player
//}