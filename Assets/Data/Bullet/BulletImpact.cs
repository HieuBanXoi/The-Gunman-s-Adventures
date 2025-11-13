using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletImpart : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Obstacle"))
        {
            this.bulletCtrl.BulletDespawn.DespawnObject();
            this.bulletCtrl.DamageSender.CreateImpactFX();
        }
        this.bulletCtrl.DamageSender.Send(other.transform);
    }
    

}
