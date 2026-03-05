using UnityEngine;

public class PlayerHPBar : HPBarAbstract, IDamageReceiveObserver
{
    //[Header("Player HP Bar")]
    
    protected override void RegisterAppearEvent()
    {
        PlayerCtrl.Instance.DamageReceiver.ObserverAdd(this);
    }
    protected override void HPShowing()
    {
        float hp = PlayerCtrl.Instance.DamageReceiver.HealthPoint;
        float maxHp = PlayerCtrl.Instance.DamageReceiver.MaxHealthPoint;
        this.sliderHP.SetCurrentHP(hp);
        this.sliderHP.SetMaxHP(maxHp);
    }
}
