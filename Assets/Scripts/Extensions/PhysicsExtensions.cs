using UnityEngine;

public static class PhysicsExtensions {
    public static RaycastHit RaycastHit(Vector3 origin, Vector3 direction) {
        return Physics.Raycast(origin, direction, out var hit)
            ? hit
            : default;
    }
}
