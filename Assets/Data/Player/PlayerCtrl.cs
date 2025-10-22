using System;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerCtrl : CoreMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected Abilities abilities;
    public Abilities Abilities { get => abilities; }
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement { get => playerMovement; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadAbilities();
        this.LoadPlayerMovement();
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

}
    
