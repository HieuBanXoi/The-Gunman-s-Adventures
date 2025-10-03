using UnityEngine;

public class GunAim : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;

    void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LootAtTarget();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }

    protected virtual void LootAtTarget()
    {
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
}
