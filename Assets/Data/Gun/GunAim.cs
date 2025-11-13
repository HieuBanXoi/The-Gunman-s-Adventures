using UnityEngine;

public abstract class GunAim : CoreMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected bool isAiming=false;
    protected virtual void Update()
    {
        this.IsAiming();
    }
    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LootAtTarget();
    }

    protected abstract void GetTargetPosition();

    protected virtual void LootAtTarget()
    {
        if (!this.IsAiming()) return;
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
        if(rot_z > 90 || rot_z < -90)
        {
            transform.parent.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
        }
    }
    protected abstract bool IsAiming();
}
