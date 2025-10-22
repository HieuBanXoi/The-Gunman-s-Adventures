using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : CoreMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected Abilities abilities;
    public Abilities Abilities { get => abilities; }
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement { get => playerMovement; }
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadAbilities();
        this.LoadPlayerMovement();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    }
    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = GetComponentInChildren<Abilities>();
        Debug.Log(transform.name + ": LoadAbilities", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
    
