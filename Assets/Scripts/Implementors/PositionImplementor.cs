using UnityEngine;

public class PositionImplementor : MonoBehaviour, IImplementor, IPositionComponent
{
    public Vector3 position
    {
        get
        {
            return transform.position;
        }

        set
        {
            transform.position = value;
        }
    }
}