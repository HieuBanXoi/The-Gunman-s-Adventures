using UnityEngine;

public class GunAimByTarget : GunAim
{
    [Header("Aim By Target")]
    [SerializeField] private Transform target;
    [SerializeField] private float aimDistance = 10f;

    protected override void Start()
    {
        base.Start();
        this.SetTarget();
    }
    protected virtual void SetTarget()
    {
        this.target = PlayerCtrl.Instance.transform;
    }
    protected override void GetTargetPosition()
    {
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }
    protected override bool IsAiming()
    {
        if (this.target == null)
        {
            this.isAiming = false;
            return this.isAiming;
        }
        float distance = Vector3.Distance(transform.position, this.target.position);
        this.isAiming = distance <= this.aimDistance;
        return this.isAiming;
    }

}
