using Svelto.ECS;
using UnityEngine;

public class ZombieTriggerImplementor : MonoBehaviour, IImplementor, IZombieTriggerComponent
{

    public DispatchOnSet<bool> triggeredAgainstTarget { get; set; }

    public bool isActive
    {
        set
        {
            GetComponent<Collider>().enabled = value;
        }
    }

    private void Awake()
    {
        triggeredAgainstTarget = new DispatchOnSet<bool>(gameObject.GetInstanceID());
    }

    private void OnTriggerEnter(Collider other)
    {
        triggeredAgainstTarget.value = true;
    }

}

