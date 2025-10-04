using Unity.Cinemachine;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = GameCtrl.Instance.MainCamera.transform;
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.mainCam.position, this.transform.position);
        return this.distance > this.disLimit;
    }
}
