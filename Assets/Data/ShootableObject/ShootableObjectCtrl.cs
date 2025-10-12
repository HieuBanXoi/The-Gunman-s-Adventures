using UnityEngine;

public abstract class ShootableObjectCtrl : CoreMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn { get => despawn; }

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject { get => shootableObject; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string path = "ShootableObject/"+this.GetObjectTypeString()+"/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(path);
        Debug.Log(transform.name + ": LoadSO", gameObject);
    }
    protected abstract string GetObjectTypeString();
}
