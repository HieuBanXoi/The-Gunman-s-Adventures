using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAbstract : CoreMonoBehaviour
{
    [SerializeField] protected EnemyCtrl shootableObjectCtrl;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Material dissolveMaterial;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
        this.LoadModel();
    }
    protected override void Start()
    {
        base.Start();
        this.LoadEffect();
    }
    protected virtual void LoadCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.spriteRenderer != null) return;
        this.spriteRenderer = this.shootableObjectCtrl.Model.GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadEffect()
    {
        if (this.dissolveMaterial != null) return;
        this.dissolveMaterial = this.spriteRenderer.material;
        //Debug.Log(transform.name + ": LoadEffect", gameObject);
    }

}
