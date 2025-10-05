using UnityEngine;
using Unity.Cinemachine;

public abstract class Despawn : CoreMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }
    
    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        DespawnObject();
    }
    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
}
