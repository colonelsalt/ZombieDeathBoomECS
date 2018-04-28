using UnityEngine;

public interface ITime
{
    float deltaTime { get; }
}

public class FrameTimer : ITime
{
    public float deltaTime
    {
        get
        {
            return Time.deltaTime;
        }
    }
}