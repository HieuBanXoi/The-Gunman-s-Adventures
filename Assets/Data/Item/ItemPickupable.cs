using System;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemPickupable : ItemAbstract
{
    [Header("Item Pickupable")]
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected new Rigidbody2D rigidbody;

    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();

    }
    protected virtual void LoadSphereCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        Debug.Assert(this.circleCollider != null, "Missing SphereCollider", this);
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.3f;
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody2D>();
        Debug.Assert(this.rigidbody != null, "Missing Rigidbody", this);
        this.rigidbody.bodyType = RigidbodyType2D.Kinematic;
        this.rigidbody.gravityScale = 0;
    }
    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }

    public virtual void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObject();
    }
}
