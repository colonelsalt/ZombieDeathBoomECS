using UnityEngine;

public class PlayerInputImplementor : IImplementor, IPlayerInputComponent
{
    public Vector3 aimPos { get; set; }
    public Ray aimRay { get; set; }
    public bool isFiring { get; set; }
}