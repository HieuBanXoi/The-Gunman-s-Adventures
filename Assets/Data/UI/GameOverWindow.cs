using UnityEngine;

public class GameOverWindow : CoreMonoBehaviour, IDamageReceiveObserver
{

    protected override void Start()
    {
        base.Start();
        this.gameObject.SetActive(false);
        this.RegisterAppearEvent();
    }
    protected virtual void RegisterAppearEvent()
    {
        PlayerCtrl.Instance.DamageReceiver.ObserverAdd(this);
    }
    public void IsDead()
    {
        Debug.Log("Game Over");
        this.gameObject.SetActive(true);
    }

    public void OnHPChanged()
    {
        //None
    }
}
