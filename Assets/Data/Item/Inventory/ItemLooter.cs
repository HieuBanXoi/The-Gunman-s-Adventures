using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemLooter : InventoryAbstract 
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected new Rigidbody2D rigidbody;
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
        this.circleCollider.radius = 0.5f;
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody2D>();
        Debug.Assert(this.rigidbody != null, "Missing Rigidbody", this);
        this.rigidbody.bodyType = RigidbodyType2D.Kinematic;
        this.rigidbody.gravityScale = 0;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
