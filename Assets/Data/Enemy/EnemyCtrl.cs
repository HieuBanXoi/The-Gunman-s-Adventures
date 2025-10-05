using UnityEngine;

public class EnemyCtrl : CoreMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO { get => enemySO; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadEnemySO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string path = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(path);
        Debug.Log(transform.name + ": LoadEnemySO", gameObject);
    }
}
