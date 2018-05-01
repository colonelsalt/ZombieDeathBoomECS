using UnityEngine;

public interface IPlayerInputComponent : IComponent
{
    Vector3 aimPos { get; set; }
    Ray aimRay { get; set; }
    bool isFiring { get; set; }
}