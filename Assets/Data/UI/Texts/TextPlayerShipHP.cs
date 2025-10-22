using UnityEngine;

public class TextPlayerShipHP : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }
    protected virtual void UpdateShipHP()
    {
        int hpMx = PlayerCtrl.Instance.DamageReceiver.MaxHealthPoint;
        int hp = PlayerCtrl.Instance.DamageReceiver.HealthPoint;
        this.text.SetText(hp + " / " + hpMx);
    }
}
