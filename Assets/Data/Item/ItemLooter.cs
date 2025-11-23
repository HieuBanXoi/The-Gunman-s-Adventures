using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ItemLooter : CoreMonoBehaviour 
{
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected new Rigidbody2D rigidbody;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadCircleCollider()
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
        // 1. L?y script c?a item
        ItemPickupable item = other.GetComponent<ItemPickupable>();
        if (item == null) return; // Không ph?i là item có th? nh?t

        // 2. L?y data t? DataSaver
        PlayerData playerData = DataSaver.Instance.playerData;
        if (playerData == null)
        {
            Debug.LogError("Không tìm th?y PlayerData!");
            return;
        }

        // 3. X? lý logic c?ng item
        bool itemWasPickedUp = false;

        switch (item.GetItemCode())
        {
            case ItemCode.Coin:
                playerData.gold += 1;
                itemWasPickedUp = true;
                Debug.Log($"Nh?t Coin. T?ng: {playerData.gold}");
                break;

            case ItemCode.Part:
                playerData.part += 1;
                itemWasPickedUp = true;
                Debug.Log($"Nh?t Part. T?ng: {playerData.part}");
                break;

            //case ItemCode.Health:
                // (Ví d? m? r?ng)
                // player.Heal(item.amount);
                // itemWasPickedUp = true;
                //break;
        }

        // 4. N?u là item ?ã x? lý, l?u game và h?y item
        if (itemWasPickedUp)
        {
            // L?u d? li?u sau khi nh?t
            DataSaver.Instance.SaveDataFn();
            UIPartAndCoin.Instance.UpdateResource();
            // G?i hàm Picked() ?? h?y item
            item.Picked();
        }
    }
}
