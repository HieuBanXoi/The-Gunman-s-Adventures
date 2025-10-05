using UnityEngine;

public class DamageSender : CoreMonoBehaviour
{
    [SerializeField] protected int damage = 10;
    public virtual void Send(Transform obj)
        {
            DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
            if (damageReceiver == null) return;
            Send(damageReceiver);
        }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        if (damageReceiver == null) return;
        damageReceiver.Detuct(damage);
    }
}
