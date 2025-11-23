using Unity.Behavior;
using UnityEngine;

public class EnemyCtrl : CoreMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO { get => enemySO; }
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected DissolveEffect dissolveEffect;
    public DissolveEffect DissolveEffect => dissolveEffect;

    [SerializeField] protected EnemyWeaponHandler weaponHandler;
    public EnemyWeaponHandler WeaponHandler => weaponHandler;

    [SerializeField] protected BehaviorGraphAgent behaviorGraphAgent;
    public BehaviorGraphAgent BehaviorGraphAgent => behaviorGraphAgent;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadSO();
        this.LoadDamageReceiver();
        this.LoadDissolveEffect();
        this.LoadGun();
        this.LoadBehavior();
    }
    protected override void Start()
    {
        this.AddHPBar2Obj(this.transform);
        this.SetTarget();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }
    protected virtual void LoadSO()
    {
        if (this.enemySO != null) return;
        string path = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(path);
        Debug.Log(transform.name + ": LoadSO", gameObject);
    }
    protected virtual void LoadDissolveEffect()
    {
        if (this.dissolveEffect != null) return;
        this.dissolveEffect = transform.GetComponentInChildren<DissolveEffect>();
        Debug.LogWarning(transform.name + ": LoadDissolveEffect", gameObject);
    }
    protected virtual void LoadGun()
    {
        if (this.weaponHandler != null) return;
        this.weaponHandler = transform.GetComponentInChildren<EnemyWeaponHandler>();
        Debug.LogWarning(transform.name + ": LoadGun", gameObject);
    }
    protected virtual void LoadBehavior()
    {
        if (this.behaviorGraphAgent != null) return;
        this.behaviorGraphAgent = transform.GetComponent<BehaviorGraphAgent>();
        Debug.LogWarning(transform.name + ": LoadBehavior", gameObject);
    }
    public virtual void AddHPBar2Obj(Transform newEnemy)
    {
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        EnemyHPBar hpBar = newHPBar.GetComponent<EnemyHPBar>();
        hpBar.SetObjectCtrl(newEnemy.GetComponent<EnemyCtrl>());
        hpBar.SetFollowTarget(newEnemy);
        newHPBar.gameObject.SetActive(true);
    }
    protected virtual void SetTarget()
    {
        if (this.behaviorGraphAgent == null) return;
        Transform player = PlayerCtrl.Instance.transform;
        this.behaviorGraphAgent.SetVariableValue("Target", player.gameObject);
    }
}
