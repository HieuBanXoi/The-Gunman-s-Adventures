using UnityEditor.PackageManager;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }
    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner allow to exist");
        EnemySpawner.instance = this;
    }
    public override Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, position, rotation);
        AddHPBar2Obj(newEnemy);
        return newEnemy;
    }
    public virtual void AddHPBar2Obj(Transform newEnemy)
    {
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPbar hpBar = newHPBar.GetComponent<HPbar>();
        hpBar.SetObjectCtrl(newEnemy.GetComponent<ShootableObjectCtrl>());
        hpBar.SetFollowTarget(newEnemy);
        newHPBar.gameObject.SetActive(true);
    }

}
