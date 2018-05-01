using UnityEngine;

// Wrapper around Unity Raycasting functionality
public interface IRayCaster
{
    int GetRayHitTarget(Ray ray, out Vector3 impactPoint);
}

public class RayCaster : IRayCaster
{
    public int GetRayHitTarget(Ray ray, out Vector3 impactPoint)
    {
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        impactPoint = hit.point;
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            return hitObject.GetInstanceID();
        }
        return -1;
    }
}