using UnityEngine;

public class GunAimByTarget : GunAim
{
    [Header("Aim By Target")]
    [SerializeField] private Transform target;
    
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override void GetTargetPosition()
    {
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }

}
