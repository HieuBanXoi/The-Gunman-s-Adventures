using UnityEngine;

public class ShootByDistance : GunShooting
{
    [Header("Shoot By Distance")]
    [SerializeField] private Transform target;
    [SerializeField] private float shootDistance = 5f;

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool IsShooting()
    {
        if (this.target == null)
        {
            this.isShooting = false;
            return this.isShooting;
        }
        float distance = Vector3.Distance(transform.position, this.target.position);
        this.isShooting = distance <= this.shootDistance;
        return this.isShooting;
    }
}
