using UnityEngine;

public class DamageSender : CoreMonoBehaviour
{
    [SerializeField] protected int damage = 10;
    public virtual void Send(Transform obj)
        {
            DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
            if (damageReceiver == null) return;
            Send(damageReceiver);
            CreateImpactFX();
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        if (damageReceiver == null) return;
        damageReceiver.Detuct(damage);
    }
    protected virtual void CreateImpactFX()
    {
        string fxName = GetImpactFX();

        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact1;
    }
}
