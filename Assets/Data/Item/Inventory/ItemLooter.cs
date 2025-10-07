using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : CoreMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected new Rigidbody rigidbody;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.Assert(this.inventory != null, "Missing Inventory", this);
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        Debug.Assert(this.sphereCollider != null, "Missing SphereCollider", this);
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.5f;
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody>();
        Debug.Assert(this.rigidbody != null, "Missing Rigidbody", this);
        this.rigidbody.isKinematic = true;
        this.rigidbody.useGravity = false;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
