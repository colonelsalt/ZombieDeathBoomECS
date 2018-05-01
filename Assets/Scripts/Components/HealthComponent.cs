using Svelto.ECS;

public interface IHealthComponent : IComponent
{
    float maxHealth { get; }
    DispatchOnSet<float> currentHealth { get; set; }
}