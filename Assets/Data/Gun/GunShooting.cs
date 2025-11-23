using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunShooting : CoreMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] public float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected WeaponHandlerAbstract weaponHandlerAbstract;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponHandlerAbstract();

    }
    protected virtual void LoadWeaponHandlerAbstract()
    {
        if (this.weaponHandlerAbstract != null) return;
        this.weaponHandlerAbstract = transform.parent.GetComponent<WeaponHandlerAbstract>();
        Debug.Log(transform.name + ": LoadWeaponHandlerAbstract", gameObject);
    }
    protected virtual void Update()
    {
        this.IsShooting();
    }

    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
        bulletCtrl.DamageSender.SetDamage(weaponHandlerAbstract.CurrentDamage);
    }
    protected abstract bool IsShooting();
}